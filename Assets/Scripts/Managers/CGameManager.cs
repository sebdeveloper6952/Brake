using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    private CCarMovement car;
    private int playMode;
    private int maxRunOverPeople; // max number of people the player can run over in GoodGuyMode

	// Use this for initialization
	void Start ()
    {
        car = CCarMovement.instance;
        maxRunOverPeople = 5;
        playMode = PlayerPrefs.GetInt("PlayMode");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playMode == 0)
            GoodGuyMode();
        else
            BadGuyMode();
	}

    private void GoodGuyMode()
    {
        // check if player has runned over the max amount of people
        if(CPeopleManager.peopleKilled >= maxRunOverPeople || car.fuelLevel <= 0)
        {
            /* player lost
               calculate score and save it in player prefs, then load the score scene
               the score in good guy mode is the distance covered */
            float score = car.distanceCovered;
            PlayerPrefs.SetFloat("GoodGuyScore", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ScoreScene");
        }
    }

    private void BadGuyMode()
    {
        // check if car runs out of gas
        if (car.fuelLevel <= 0f)
        {
            /* player lost
               calculate score and save it in player prefs, then load the score scene 
               the score in bad guy mode is the number of people run over multiplied by distance covered */
            float distance = car.distanceCovered;
            int peopleKilled = CPeopleManager.peopleKilled;
            PlayerPrefs.SetFloat("BadGuyScore", distance);
            PlayerPrefs.SetInt("PeopleKilled", peopleKilled);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ScoreScene");
        }
    }

    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3f);
    }
}
