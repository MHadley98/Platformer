using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extra using statment to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    //This will be called by the button component when it is clicked
    public void StartGame()
    {

        //reset the score
        PlayerPrefs.DeleteKey("score");

        //reset the lives
        PlayerPrefs.DeleteKey("lives");

        //Loads Level 1
        SceneManager.LoadScene("Level1");

    }

}
