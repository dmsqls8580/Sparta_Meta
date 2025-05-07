using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionUI; // "E�� ���� ��ȣ�ۿ�" �ȳ� UI
    private bool playerInRange = false;

    public string[] dialogueLines = new string[] // ��� �迭
    {
        "�ȳ��ϼ���, �����ڴ�!",
        "�� ������ �����ϰ� ��ȭ�ο���.",
        "Ȥ�� �̴ϰ����� �غ��� �����Ű���?"
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
    // NPCInteraction.cs ���ο� �߰� (optional, �������� ��ġ ���� ��)
    private void LateUpdate()
    {
        if (interactionUI != null)
        {
            // UI�� �׻� NPC �Ӹ� ���� ��ġ�ϵ��� ����
            Vector3 offset = new Vector3(0, 1f, 0); // Y�� ���� 1��ŭ
            interactionUI.transform.position = transform.position + offset;

            // ī�޶� ������ ���ϵ��� UI ȸ��
            interactionUI.transform.rotation = Quaternion.identity;
        }
    }
    private void StartDialogue()
    {
        // ���⼭ ��ȭ �ý����� �����ϵ��� ����
        DialogueManager.Instance.StartDialogue(dialogueLines, OnDialogueEnd);
    }

    private void OnDialogueEnd()
    {
        // ��ȭ ������ �̴ϰ��� ����
        GameManager.Instance.StartGame();
    }

    private void StartMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene");

    }
}
