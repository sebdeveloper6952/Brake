using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDistance_Fuel : MonoBehaviour
{
    public Text distanceText;
    public Text fuelText;

    private CCarMovement car;
    private string distanceSt;
    private string fuelSt;
	// Use this for initialization
	void Start ()
    {
        car = CCarMovement.instance;
        distanceSt = "Distance: ";
        fuelSt = "Fuel: ";
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceText.text = string.Concat(distanceSt, car.distanceCovered.ToString("F0"));
        fuelText.text = string.Concat(fuelSt, car.fuelLevel.ToString("F0"));
	}
}
