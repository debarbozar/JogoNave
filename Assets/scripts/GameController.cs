using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Loose gameOverScreen;
    [SerializeField] private ScorePoint ScorePointScript;
    public void GameOver()
    {
        //gameOverScreen.Setup(ScorePointScript.getScore());
    }


}
