using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFuelSpawner : MonoBehaviour
{
    /* This class handles the spawning of fuel pickups. */

    public GameObject fuelPickup;
    public float minTime;
    public float maxTime;

    private CTileManager tileManager;
    private float spawnTime;

    private void Start()
    {
        tileManager = CTileManager.instance;
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        if (spawnTime <= 0f)
            SpawnFuelPickup();
        spawnTime -= Time.deltaTime;
    }

    private void SpawnFuelPickup()
    {
        fuelPickup.SetActive(true);
        fuelPickup.transform.position = tileManager.center[0].transform.position;
        spawnTime = Random.Range(minTime, maxTime);
    }
}
