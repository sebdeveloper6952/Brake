using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public Text distanceText;

    private float distanceCovered;
    private float carVelocity;

	// Use this for initialization
	void Start ()
    {
        distanceCovered = 0;   	
	}
	
	// Update is called once per frame
	void Update ()
    {
        carVelocity = CCarMovement.instance.rb.velocity.magnitude;
        if(carVelocity > 0.1)
        {
            distanceCovered += carVelocity/50f;
            distanceText.text = distanceCovered.ToString("F0"); 
        }
	}
}
