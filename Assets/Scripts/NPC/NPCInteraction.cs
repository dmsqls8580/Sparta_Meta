using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionUI; // "E를 눌러 상호작용" 안내 UI
    private bool playerInRange = false;

    public string[] dialogueLines = new string[] // 대사 배열
    {
        "안녕하세요, 여행자님!",
        "이 마을은 조용하고 평화로워요.",
        "혹시 미니게임을 해보고 싶으신가요?"
    };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionUI.SetActive(false);
        }
    }
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactionUI.SetActive(false);
            StartDialogue();
        }
    }
    // NPCInteraction.cs 내부에 추가 (optional, 동적으로 위치 조정 시)
    private void LateUpdate()
    {
        if (interactionUI != null)
        {
            // UI가 항상 NPC 머리 위에 위치하도록 고정
            Vector3 offset = new Vector3(0, 1f, 0); // Y축 위로 1만큼
            interactionUI.transform.position = transform.position + offset;

            // 카메라 방향을 향하도록 UI 회전
            interactionUI.transform.rotation = Quaternion.identity;
        }
    }
    private void StartDialogue()
    {
        // 여기서 대화 시스템을 시작하도록 구현
        DialogueManager.Instance.StartDialogue(dialogueLines, OnDialogueEnd);
    }

    private void OnDialogueEnd()
    {
        // 대화 끝나면 미니게임 시작
        GameManager.Instance.StartGame();
    }

    private void StartMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene");

    }
}
