using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFuelSpawner : MonoBehaviour
{
    /* This class handles the spawning of fuel pickups. */

    public GameObject fuelPickup;
    public float minNormalLevel;
    public float maxNormalLevel;
    public float minLowFuelLevel;
    public float maxLowFuelLevel;

    private CTileManager tileManager;
    private CCarMovement car;
    private const float lowFuelLevel = 25f;
    private float spawnLevel; // random fuel level at which the fuel spawns
    private bool lowFuel; // is the car low on fuel? Low fuel <= 25%

    private void Start()
    {
        tileManager = CTileManager.instance;
        car = CCarMovement.instance;
        spawnLevel = Random.Range(minNormalLevel, maxNormalLevel);
        lowFuel = false;
    }

    private void Update()
    {
        if (car.fuelLevel <= spawnLevel && !fuelPickup.activeSelf)
        {
            SpawnFuelPickup();
        }
        else if (car.fuelLevel <= lowFuelLevel && !lowFuel)
        {
            spawnLevel = Random.Range(minLowFuelLevel, maxLowFuelLevel); // if fuel level is low, add more posibilities to spawn fuel
            lowFuel = true;
        }
        else if(car.fuelLevel > lowFuelLevel)
        {
            lowFuel = false;
        }
    }

    private void SpawnFuelPickup()
    {
        fuelPickup.SetActive(true);
        if(Random.Range(0,2) == 0)
        {
            fuelPickup.transform.position = tileManager.center[0].transform.position + Vector3.up;
        }
        else
        {
            fuelPickup.transform.position = tileManager.center[0].transform.position + Vector3.right;
        }
        spawnLevel = Random.Range(minNormalLevel, maxNormalLevel);
        fuelPickup.SendMessage("ActivateTimer", SendMessageOptions.DontRequireReceiver);
    }
}
