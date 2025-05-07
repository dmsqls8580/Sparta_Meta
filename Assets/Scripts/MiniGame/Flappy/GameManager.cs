using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int currentScore = 0;

    private UIManager uiManager;

    public static bool isFirstLoading = true;

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // UIManager 찾기
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        if (isFirstLoading)
        {
            uiManager.ChangeState(UIState.Home); // HomeUI부터 시작!
            Time.timeScale = 0f;
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        uiManager.SetPlayGame(); // Game UI 보이기
        Time.timeScale = 1f;            // 게임 재개
        currentScore = 0;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        // 최고 점수 저장
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.Save();
        }

        // UI 상태 변경
        uiManager.SetGameOver();

        // GameOverUI 점수 표시
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.SetRestart();
            gameOverUI.ShowScore(currentScore, PlayerPrefs.GetInt("BestScore", 0));
        }
        else
        {
            Debug.LogWarning("GameOverUI is not found.");
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);

        uiManager.UpdateScore(currentScore);
    }
}
