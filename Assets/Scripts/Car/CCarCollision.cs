using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCarCollision : MonoBehaviour
{
    public Text peopleText;

    void OnTriggerEnter2D(Collider2D other)
    {
        // if other is a person, it will pick up this message
        other.SendMessage("RunnedOver", SendMessageOptions.DontRequireReceiver);
        // if other is a fuel tank, pick up fuel tank
        peopleText.SendMessage("UpdateText", SendMessageOptions.DontRequireReceiver);
    }
}
