using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    //variable to let us add to score
    //public so we can drag and drop
    public Score scoreObject;

    //variable to hold coin's point value
    //public so we can edit in editor
    public int coinValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //unity calls coin this function when coin touches ant other obeject
    //if the player touches the coin should disappesr and score should go up
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if what we touched is the player
        Player playerScript = collision.collider.GetComponent<Player>();

        //if the thing touched has player script, means it is player so...
        if (playerScript)
        {
            //we hit the player

            //add to score based on coin value
            scoreObject.AddScore(coinValue);

            //destroy the gameObject that script is attached to(coin)
            Destroy(gameObject);
        }
    }

}
