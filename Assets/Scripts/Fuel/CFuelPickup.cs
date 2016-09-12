using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFuelPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("RefillFuelTank", SendMessageOptions.DontRequireReceiver);
    }
}
