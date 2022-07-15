using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseSceneController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;

    private void Start()
    {
        var score = PlayerPrefs.GetInt("score");
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);        
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
