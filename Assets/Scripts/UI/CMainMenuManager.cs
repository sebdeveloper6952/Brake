using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CMainMenuManager : MonoBehaviour
{
    private float xAccelInput;
    private const int goodGuyMode = 0;
    private const int badGuyMode = 1;
    private string prefName;
    
    void Awake()
    {
        if (!PlayerPrefs.HasKey("NotFirstTimePlayed"))
        {
            PlayerPrefs.SetString("NotFirstTimePlayed", "true");
            PlayerPrefs.SetFloat("GoodGuyHighScore", 0f);
            PlayerPrefs.SetFloat("BadGuyHighScore", 0f);
            PlayerPrefs.Save();
        }
    }

    void Start ()
    {
        prefName = "PlayMode";
	}

	void Update ()
    {
        xAccelInput = Input.acceleration.x;
        if(xAccelInput <= -0.6f)
        {
            // start game in good guy mode
            PlayerPrefs.SetInt(prefName, goodGuyMode);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainScene");
        }
        else if(xAccelInput >= 0.6f)
        {
            // start game in bad guy mode
            PlayerPrefs.SetInt(prefName, badGuyMode);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainScene");
        }
	}
}
