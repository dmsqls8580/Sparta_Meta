using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public int currentScore = 0;
    public Text scoreText;
    public Button endGameButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void StartMiniGame()
    {
        // ¾À ÀüÈ¯
        SceneManager.LoadScene("MiniGameScene");
    }

    void Start()
    {
        UpdateScoreUI();

        endGameButton.onClick.AddListener(() =>
        {
            GameData.LastMiniGameScore = currentScore;
            if (currentScore > GameData.BestScore)
                GameData.BestScore = currentScore;

            SceneManager.LoadScene("MapScene");
        });
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Á¡¼ö: {currentScore}";
    }
}