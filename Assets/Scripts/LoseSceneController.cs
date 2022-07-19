using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseSceneController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;
    public Animator SceneTransition;

    private void Start()
    {
        var score = PlayerPrefs.GetInt("score");
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    public void RestartGame()
    {
        StartCoroutine(LoadLevel(1));       
    }
    public void QuitToMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneIndex);
    }
}
