using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleKilledText : MonoBehaviour
{
    public Text text;

    private void Update()
    {
        text.text = string.Concat("People killed: ", CPeopleManager.peopleKilled.ToString());
    }
}
