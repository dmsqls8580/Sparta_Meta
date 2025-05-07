using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }
        scoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
        else
            Debug.LogError("ScoreText is not assigned in the inspector.");
    }


    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}