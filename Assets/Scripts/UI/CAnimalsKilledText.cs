using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAnimalsKilledText : MonoBehaviour
{
    public Text text;

    private void UpdateText()
    {
        text.text = string.Concat("Animals killed: ", CAnimalsManager.animalsKilled.ToString());
    }
}
