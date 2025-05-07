using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// ������ UI ���¸� �����ϴ� ������
public enum UIState
{
    Home,
    Game,
    GameOver,
}
public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    private UIState currentState; // ���� UI ����

    private void Awake()
    {
        // �ڽ� ������Ʈ���� ������ UI�� ã�� �ʱ�ȭ
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        // �ʱ� ���¸� Ȩ ȭ������ ����
        ChangeState(UIState.Home);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }
    // ���� UI ���¸� �����ϰ�, �� UI ������Ʈ�� ���¸� ����
    public void ChangeState(UIState state)
    {
        currentState = state;
        Debug.Log("UI ���� ����: " + currentState);

        // �� UI�� �ڽ��� �������� �� �������� �Ǵ��ϰ� ǥ�� ���� ����
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }

    public void UpdateScore(int score)
    {
        if (gameUI != null)
        {
            gameUI.UpdateScore(score);
        }
        else
        {
            Debug.LogError("gameUI is null in UIManager.");
        }
    }
}