using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    //Unity calls this function automatically
    //when our spikes touch any other object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the thing we collideded with has player script
        Player playerScript = collision.collider.GetComponent<Player>();

        //only do something if the player runs into
        if (playerScript != null)
        {
            //we did hit player
            playerScript.Kill();
        }
    }

}
