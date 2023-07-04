using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void OnClickStartButton()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
