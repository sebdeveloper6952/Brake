using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CScoreScreen : MonoBehaviour
{
    /* this script shows the score to the player, depending on whether he was playing good or bad guy mode  */
    public Text scoreText;
    public Text highScoreText;

    private float xAccelInput;
    private float yAccelInput;
    private int playMode;
    private float score;
    private float highScore;
    private int animalsKilled;
    private float distance;

    void Start()
    {
        playMode = PlayerPrefs.GetInt("PlayMode");
        CalculateScore();
    }

    void Update()
    {
        xAccelInput = Input.acceleration.x;
        yAccelInput = Input.acceleration.y;
        if(xAccelInput <= -0.6f)
        {
            // reset game
            SceneManager.LoadScene("MainScene");
        }
        else if(yAccelInput <= -0.9f)
        {
            // load main menu
            SceneManager.LoadScene("MainMenu");
        }
    }

    void CalculateScore()
    {
        if(playMode == 0)
        {
            // in good guy mode, the score is the distance traveled
            score = PlayerPrefs.GetFloat("GoodGuyScore");
            highScore = PlayerPrefs.GetFloat("GoodGuyHighScore");
            // check if it is a new high score
            if(score > highScore)
            {
                highScoreText.text = "New High Score!";
                PlayerPrefs.SetFloat("GoodGuyHighScore", score);
                PlayerPrefs.Save();
            }
            else
            {
                highScoreText.text = "The high score is: " + highScore.ToString("F2");
            }
            scoreText.text = "Your score is " + score.ToString("F2");
        }
        else
        {
            // in bad guy mode, the score is the number of people ran over multiplied by the distance
            distance = PlayerPrefs.GetFloat("BadGuyScore");
            animalsKilled = PlayerPrefs.GetInt("AnimalsKilled");
            highScore = PlayerPrefs.GetFloat("BadGuyHighScore");
            score = distance * animalsKilled;
            // check if it is a new high score
            if(score > highScore)
            {
                highScoreText.text = "New High Score!";
                PlayerPrefs.SetFloat("BadGuyHighScore", score);
                PlayerPrefs.Save();
            }
            else
            {
                highScoreText.text = "The high score is: " + highScore.ToString("F2");
            }
            scoreText.text = "You killed " + animalsKilled + " animals, and traveled " + distance.ToString("F2") + " meters. Your score is: " + score.ToString("F2");
        }
    }
}
