using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFuelPickup : MonoBehaviour
{
    private float lifeTime;
    private AudioSource audioSource;
    private Renderer renderer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponentInChildren<Renderer>();
    }

    private void Start()
    {
        lifeTime = 10f;
    }

    private IEnumerator RefillFuelTank()
    {
        CCarMovement.instance.fuelLevel = 100f;
        renderer.enabled = false;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Disables the fuel pickup object after some time, if the player did not picked it up
    /// </summary>
    private IEnumerator ActivateTimer()
    {
        renderer.enabled = true;
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
}
