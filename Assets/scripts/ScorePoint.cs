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
        if(collision.CompareTag("Platform") && !last3Platforms.Contains(collision.GetInstanceID()))
        {
            last3Platforms.Add(collision.GetInstanceID());
            scoreNum++;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        scoreNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + (scoreNum * 10);

        if (last3Platforms.Count >= 2)
        {
            last3Platforms.RemoveAt(0);
        }
    }
}
