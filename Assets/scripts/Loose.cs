using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loose : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreMessage;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject InGameSoundtrack;
    [SerializeField] private GameObject GameOverSoundtrack;
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
        InGameSoundtrack.GetComponent<AudioSource>().Stop();
        GameOverSoundtrack.GetComponent<AudioSource>().Play();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        scoreMessage.text = scorePointScript.getScore() + " Points";
    }
}
