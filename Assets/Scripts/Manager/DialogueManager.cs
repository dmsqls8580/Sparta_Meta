using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;       // 대화 UI 전체 패널
    public TextMeshProUGUI dialogueText;   // 대화 출력 텍스트
    public float typingSpeed = 0.05f;

    private string[] lines;
    private int currentLineIndex = 0;
    private Action onDialogueEnd;          // 대화 종료 시 콜백
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            SkipOrContinue();
        }
    }

    public void StartDialogue(string[] dialogueLines, Action onEnd)
    {
        Debug.Log("StartDialogue 호출됨");

        lines = dialogueLines;
        onDialogueEnd = onEnd;
        currentLineIndex = 0;

        dialoguePanel.SetActive(true);
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLineIndex < lines.Length)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeLine(lines[currentLineIndex]));
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void SkipOrContinue()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = lines[currentLineIndex - 1];  // 현재 라인 즉시 출력
            isTyping = false;
        }
        else
        {
            ShowNextLine();
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        onDialogueEnd?.Invoke();
    }
}
