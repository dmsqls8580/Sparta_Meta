using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    // �÷��̾ ������ ������ �̴ϰ��� ������ ��ȯ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾ Ʈ���� ������ ������
        {
            Debug.Log("�̴ϰ��� ����!");
            SceneManager.LoadScene("MiniGameScene");  // �̴ϰ��� ������ ��ȯ
        }
    }
}
