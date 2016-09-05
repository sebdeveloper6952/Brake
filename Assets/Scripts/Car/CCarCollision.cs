using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCarCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("RunnedOver", SendMessageOptions.DontRequireReceiver);
    }
}
