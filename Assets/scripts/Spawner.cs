using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject star;
    private float platformSpawnTime = 2f;
    private float starSpawnTime = 5;
    private float starSpawnCountTime = 0;
    private float platformSpawnCountTime = 2f;
    private Vector2 spawnPosition;


    public void SpawnStar()
    {
        this.starSpawnCountTime += Time.deltaTime;
        this.spawnPosition = this.transform.position;
        this.spawnPosition.x = Random.Range(-9.5f, 9.5f);

        if (starSpawnCountTime >= starSpawnTime)
        {
            starApperance();
            starSpawnCountTime = Random.Range(0f, 3f);
        }
    }

    public void starApperance()
    {
        Debug.Log("Star");
        Instantiate(star, spawnPosition, Quaternion.identity);
    }

    public void SpawnPlatform()
    {
        this.platformSpawnCountTime += Time.deltaTime;
        this.spawnPosition = this.transform.position;
        this.spawnPosition.x = Random.Range(-9.5f, 9.5f);

        if (platformSpawnCountTime >= platformSpawnTime)
        {
            platformApperance();
            platformSpawnCountTime = 0;
        }

    }

    public void platformApperance()
    {
        Instantiate(platform, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        SpawnPlatform();
        SpawnStar();
    }
}
