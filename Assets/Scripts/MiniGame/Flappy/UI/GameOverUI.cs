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
        // 마우스 클릭 시 (왼쪽 버튼)
        if (Input.GetMouseButtonDown(0))
        {
            RestartToHome(); // 홈 화면으로 재시작
        }

        // ESC 키 입력 시 → MapScene으로 이동
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitToMap(); // 맵 씬으로 이동
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
        // GameManager의 Start에서 SetHome()만 하므로 isFirstLoading = false 유지
    }

    // ESC 누르면 미니게임 종료 → 맵 씬으로 복귀
    private void ExitToMap()
    {
        SceneManager.LoadScene("MapScene"); // 씬 이름이 실제 MapScene이라면
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
