using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] Canvas gameOverCanvas;

    private int score = 0;
    private string StoreHighScore = "HighScore";

    private void Start()
    {

        currentScore.text = score.ToString();
        highScore.text = PlayerPrefs.GetInt(StoreHighScore,0).ToString();
        gameOverCanvas.enabled = false;
        EventManager.Instance.ScoreUpdateEvent += OnUpdateScore;
        EventManager.Instance.GameOverEvent += OnGameOver;
    }
    private void OnDisable()
    {
        EventManager.Instance.ScoreUpdateEvent -= OnUpdateScore;
        EventManager.Instance.GameOverEvent -= OnGameOver;
    }

    public void ClickOnRestartButton()
    {
        SceneManager.LoadScene(0);
    }

    private void CheckForHighScore()
    {
        if(score > PlayerPrefs.GetInt(StoreHighScore))
        {
            PlayerPrefs.SetInt(StoreHighScore, score);
        }
    }

    private void OnUpdateScore(object sender, ScoreUpdateEventArgs e)
    {
        int score1 = e.number1;
        int score2 = e.number2;
        int totalScore = score1 + score2;
        score += totalScore;

        currentScore.text = score.ToString();

        CheckForHighScore();
    }

    private void OnGameOver(object sender, EventArgs e)
    {
        gameOverCanvas.enabled = true;
    }

}
