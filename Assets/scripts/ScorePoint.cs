using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int scoreNum;
    private List<int> last3Platforms = new List<int>();


    public int getScore()
    {
        return scoreNum;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            scoreNum += 10;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("OneWayPlatform") && !last3Platforms.Contains(collision.collider.GetInstanceID()))
        {
            last3Platforms.Add(collision.collider.GetInstanceID());
            scoreNum += 1;
        }

    }

    void Start()
    {
        scoreNum = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreNum;

        if (last3Platforms.Count >= 2)
        {
            last3Platforms.RemoveAt(0);
        }
    }
}
