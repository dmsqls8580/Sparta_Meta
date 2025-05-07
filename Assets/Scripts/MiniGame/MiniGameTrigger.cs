using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    // 플레이어가 영역에 들어오면 미니게임 씬으로 전환
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어가 트리거 영역에 들어오면
        {
            Debug.Log("미니게임 시작!");
            SceneManager.LoadScene("MiniGameScene");  // 미니게임 씬으로 전환
        }
    }
}
