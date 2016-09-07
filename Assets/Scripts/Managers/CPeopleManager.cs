using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPeopleManager : MonoBehaviour
{
    public List<GameObject> people; // people pool
    public float minTime; // minimum time between spawns
    public float maxTime; // maximum time between spawns
    public GameObject car; // the car, used to track its position and spawn persons
    public static int peopleKilled; // amount of people runned over

    private float timeToSpawn; // time to spawn next person
    private Vector3 lOffset; // offset to the left of the car to spawn persons
    private Vector3 rOffset;

    private void Start()
    {
        timeToSpawn = Random.Range(minTime, maxTime);
        lOffset = new Vector3(1.28f, 1.4f, 0f);
        rOffset = new Vector3(2.56f, 0.76f, 0f);
        peopleKilled = 0;
    }

    private void Update()
    {
        // decrease timeToSpawn
        timeToSpawn -= Time.deltaTime;
        // if timeToSpawn reaches 0, spawn a person and reset timeToSpawn
        if (timeToSpawn <= 0)
        {
            SpawnPerson();
            timeToSpawn = Random.Range(minTime, maxTime);
        }
    }

    private void SpawnPerson()
    {
        // choose a random direction and spawn point
        float direction = Random.Range(-1, 2);
        Vector3 spawnPos;
        if(direction > 0)
        {
            direction = 1;
            spawnPos = car.transform.position + lOffset;
        }
        else
        {
            direction = -1;
            spawnPos = car.transform.position + rOffset;
        }
        for(int i = 0; i < people.Count; i++)
        {
            if(!people[i].activeSelf)
            {
                people[i].SetActive(true);
                people[i].transform.position = spawnPos;
                people[i].SendMessage("SetDirectionAndSpeed", direction, SendMessageOptions.DontRequireReceiver);
                people[i].SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
                break;
            }
        }
    }
}
