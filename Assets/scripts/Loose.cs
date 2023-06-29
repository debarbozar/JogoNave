using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loose : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreMessage;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private ScorePoint scorePointScript;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Setup();
        }
        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Setup()
    {
        gameOverScreen.gameObject.SetActive(true);
        scoreMessage.text = (scorePointScript.getScore() * 10) + " Points";
    }
}
