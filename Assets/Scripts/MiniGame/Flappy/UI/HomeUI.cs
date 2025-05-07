using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager); // BaseUI���� UIManager ����
        // ��ư Ŭ�� �̺�Ʈ ����
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.StartGame(); // GameManager ���� ���� ����
    }

    public void OnClickExitButton()
    {
        Application.Quit(); // ����� ���ø����̼� ���� (�����Ϳ����� �۵����� ����)
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}