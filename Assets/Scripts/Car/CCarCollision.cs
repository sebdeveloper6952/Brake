using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCarCollision : MonoBehaviour
{
    public Text peopleText;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("RunnedOver", SendMessageOptions.DontRequireReceiver);
        peopleText.SendMessage("UpdateText", SendMessageOptions.DontRequireReceiver);
    }
}
