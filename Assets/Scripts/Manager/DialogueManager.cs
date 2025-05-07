using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;       // ��ȭ UI ��ü �г�
    public TextMeshProUGUI dialogueText;   // ��ȭ ��� �ؽ�Ʈ
    public float typingSpeed = 0.05f;

    private string[] lines;
    private int currentLineIndex = 0;
    private Action onDialogueEnd;          // ��ȭ ���� �� �ݹ�
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
        Debug.Log("StartDialogue ȣ���");

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
            dialogueText.text = lines[currentLineIndex - 1];  // ���� ���� ��� ���
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
