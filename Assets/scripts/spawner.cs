using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private float spawnTime = 3f;
    private float spawnCountTime = 0;
    private Vector2 spawnPosition;

    //-12.25
    //12.17
    void Start()
    {

    }

    public void SpawnPlatform()
    {
        this.spawnCountTime += Time.deltaTime;
        this.spawnPosition = this.transform.position;
        this.spawnPosition.x = Random.Range(-12.25f,  12.17f);

        if(spawnCountTime >= spawnTime)
        {
            platformApperance();
            spawnCountTime = 0;
        }

    }

    public void platformApperance()
    {
        Instantiate(platform, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        SpawnPlatform();
    }
}
