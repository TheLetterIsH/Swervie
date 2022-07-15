using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEventController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        score = 0;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score = 0;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);

        }

    }
}
