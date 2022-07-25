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
    [SerializeField] public GameObject playerParticles;

    [SerializeField] public AudioSource collect;
    [SerializeField] public AudioSource death;

    private ScreenShake screenShake;

    private void Start()
    {
        screenShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ScreenShake>();
    }

    private void Awake()
    {
        score = 0;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            screenShake.CamShake();

            collect.Play();

            GameObject pointFX = Instantiate(pointParticles, collision.gameObject.transform.position, Quaternion.identity);

            pointFX.GetComponent<ParticleSystem>().Play();

            score++;
            scoreText.text = score.ToString();

            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            screenShake.CamShake();

            death.Play();

            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            GameObject playerFX = Instantiate(playerParticles, gameObject.transform.position, Quaternion.identity);

            playerFX.GetComponent<ParticleSystem>().Play();

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

        yield return new WaitForSeconds(0.75f);

        SceneManager.LoadScene(2);
    }
}
