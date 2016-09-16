using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimalsManager : MonoBehaviour
{
    public List<GameObject> animalsList; // animal pool
    public float minTime; // minimum time between spawns
    public float maxTime; // maximum time between spawns
    public GameObject car; // the car, used to track its position and spawn persons
    public static int animalsKilled; // amount of animals killed

    private float timeToSpawn; // time to spawn next person
    private Vector3 offset; // offset to the left of the car to spawn animals
    private Vector3 spawnPos;
    private CTileManager tileManager;

    private void Start()
    {
        tileManager = CTileManager.instance;
        timeToSpawn = Random.Range(minTime, maxTime);
        offset = new Vector3(1.28f, 0.64f, 0f);
        animalsKilled = 0;
    }

    private void Update()
    {
        // decrease timeToSpawn
        timeToSpawn -= Time.deltaTime;
        // if timeToSpawn reaches 0, spawn an animal and reset timeToSpawn
        if (timeToSpawn <= 0)
        {
            SpawnAnimal();
            timeToSpawn = Random.Range(minTime, maxTime);
        }
    }

    /// <summary>
    /// Sets the direction for the new animal, and spawns it.
    /// </summary>
    private void SpawnAnimal()
    {
        // choose a random direction and spawn point
        float direction = Random.Range(-1, 2);
        if (direction > 0)
        {
            direction = 1; // movement direction is downwards
            spawnPos = tileManager.leftSideW[0].transform.position + offset;
        }
        else
        {
            direction = -1; // movement direction is upwards
            spawnPos = tileManager.rightSideW[0].transform.position + offset;
        }
        for (int i = 0; i < animalsList.Count; i++)
        {
            if (!animalsList[i].activeSelf)
            {
                animalsList[i].SetActive(true);
                animalsList[i].transform.position = spawnPos;
                animalsList[i].SendMessage("SetDirectionAndSpeed", direction, SendMessageOptions.DontRequireReceiver);
                animalsList[i].SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
                break;
            }
        }
    }
}
