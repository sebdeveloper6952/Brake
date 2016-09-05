using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameObjectDestroyer : MonoBehaviour
{
    private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, audioSource.clip.length);	
	}
}
