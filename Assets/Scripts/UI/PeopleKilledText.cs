using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleKilledText : MonoBehaviour
{
    public Text text;

    private void UpdateText()
    {
        text.text = string.Concat("People killed: ", CPeopleManager.peopleKilled.ToString());
    }
}
