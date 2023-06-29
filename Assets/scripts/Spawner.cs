using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private float spawnTime = 2f;
    private float spawnCountTime = 3f;
    private Vector2 spawnPosition;


    public void SpawnPlatform()
    {
        this.spawnCountTime += Time.deltaTime;
        this.spawnPosition = this.transform.position;
        this.spawnPosition.x = Random.Range(-5.75f, 5.75f);

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
