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
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // UIManager ã��
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        if (isFirstLoading)
        {
            uiManager.ChangeState(UIState.Home); // HomeUI���� ����!
            Time.timeScale = 0f;
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        uiManager.SetPlayGame(); // Game UI ���̱�
        Time.timeScale = 1f;            // ���� �簳
        currentScore = 0;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        // UI ���� ����
        uiManager.SetGameOver();

        // GameOverUI �ؽ�Ʈ Ȱ��ȭ
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.SetRestart();
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
