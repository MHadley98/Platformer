using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extra using statment to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    //variable to let us save the score
    //public so we can drag and drop
    public Score scoreObject;

    //designer variable 
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the thing we collideded with has player script
        Player playerScript = collision.collider.GetComponent<Player>();

        //only do something if the player runs into
        if (playerScript != null)
        {
            //we did hit player

            //save the score using score object reference
            scoreObject.SaveScore();

            //load the next level
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
