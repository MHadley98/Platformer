using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using statement for unity ui code
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //variable to track visible text score
    //public to let us drag and drop in editor
    public Text scoreText;

    //variable to track numerical score
    //private so other scripts don't change it directly
    //Default to 0 when starting
    private int numericalScore = 0;

	// Use this for initialization
	void Start () {

        //get the score from prefs data base, use default of 0 if no score saved
        //store result in numerical score variable
        numericalScore = PlayerPrefs.GetInt("score",0);

        //update visual score
        scoreText.text = numericalScore.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //function to increase the score
    //public so other scripts can use it such as the coin
    public void AddScore(int _toAdd)
    {
        //add the amount to the numerical score
        numericalScore = numericalScore + _toAdd;

        //update the visual score
        scoreText.text = numericalScore.ToString();

    }

    //function to save the score to the player preferences
    //public so it can be triggered from other script(door)
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", numericalScore);
    }

}
