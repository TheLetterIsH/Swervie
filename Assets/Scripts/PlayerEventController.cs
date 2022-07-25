using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEventController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;
    public Animator SceneTransition;
    
    [SerializeField] public GameObject centre;

    [SerializeField] public GameObject pointParticles;

    private void Awake()
    {
        score = 0;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            GameObject particles = Instantiate(pointParticles, collision.gameObject.transform.position, Quaternion.identity);

            particles.GetComponent<ParticleSystem>().Play();

            score++;
            scoreText.text = score.ToString();

            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            PlayerPrefs.SetInt("score", score);
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
            centre.GetComponent<BallRotation>().speed = 0;
            StartCoroutine("LoadLevel");
        }

    }

    IEnumerator LoadLevel()
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(2);
    }
}
