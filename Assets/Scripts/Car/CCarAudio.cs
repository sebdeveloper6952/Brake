using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarAudio : MonoBehaviour
{
    public AudioClip drivingClip;
    public AudioClip brakingClip;

    private AudioSource audioSource;
    private bool braking;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = drivingClip;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        braking = Input.acceleration.x < -0.1f;
        if(braking && audioSource.clip == drivingClip)
        {
            audioSource.clip = brakingClip;
            audioSource.Play();
            audioSource.loop = false;
        }
        else if(!braking && audioSource.clip == brakingClip)
        {
            audioSource.clip = drivingClip;
            audioSource.Play();
            audioSource.loop = true;
        }
	}
}
