using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;
            Debug.Log("Coin collected! Scrore: " + score);
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            score--;
            Debug.Log("Trap hit! Score: " + score);
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
