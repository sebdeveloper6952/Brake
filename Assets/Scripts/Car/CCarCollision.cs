using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCarCollision : MonoBehaviour
{
    public Text animalText;

    void OnTriggerEnter2D(Collider2D other)
    {
        // if other is an animal, it will pick up this message
        if (other.CompareTag("Animal"))
        {
            other.SendMessage("RunnedOver", SendMessageOptions.DontRequireReceiver);
            animalText.SendMessage("UpdateText", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            other.SendMessage("RefillFuelTank", SendMessageOptions.DontRequireReceiver);
        }
    }
}
