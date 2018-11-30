using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extra using statment to allow us to use the scene management functions
using UnityEngine.SceneManagement;


public class TitleButton : MonoBehaviour {

    //called when menu button is pressed
    public void BackToMenu()
    {
        //return to menu scene
        SceneManager.LoadScene("Title");

    }

}
