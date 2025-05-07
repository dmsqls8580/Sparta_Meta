using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : BaseUI
{
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI ExitText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }

    public void SetRestart()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }
        restartText.gameObject.SetActive(true);
        ExitText.gameObject.SetActive(true);
    }

    private void Update()
    {
        // ���콺 Ŭ�� �� (���� ��ư)
        if (Input.GetMouseButtonDown(0))
        {
            RestartToHome(); // Ȩ ȭ������ �����
        }

        // ESC Ű �Է� �� �� MapScene���� �̵�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitToMap(); // �� ������ �̵�
        }
    }

    public void ShowScore(int currentScore, int bestScore)
    {
        if (currentScoreText != null)
            currentScoreText.text = "Score: " + currentScore;

        if (bestScoreText != null)
            bestScoreText.text = "Best: " + bestScore;
    }

    private void RestartToHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // GameManager�� Start���� SetHome()�� �ϹǷ� isFirstLoading = false ����
    }

    // ESC ������ �̴ϰ��� ���� �� �� ������ ����
    private void ExitToMap()
    {
        SceneManager.LoadScene("MapScene"); // �� �̸��� ���� MapScene�̶��
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
