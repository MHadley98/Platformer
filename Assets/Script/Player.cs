﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extra using statment to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //designer variables
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    //variable to keep a reference to the lives display object
    public Lives livesObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Get axis input from Unity
        float leftRight = Input.GetAxis(horizontalAxis);

        //Create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        //Make direction vector length 1
        direction = direction.normalized;

        //calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        //give the velocity to the rigid body
        physicsBody.velocity = velocity;


        //tell animator our speed
        playerAnimator.SetFloat("walkSpeed", Mathf.Abs(velocity.x));

        //flip sprite if moving backwards

        if (velocity.x<0)
            {
                playerSprite.flipX = true;
            }
            else
            {
                playerSprite.flipX = false;
            }

        //Jumpuing

        //detect if touching ground
        //Get the LayerMask from Unity using the name of the layer
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        //Ask the player's collider if we are touching the LayerMask
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);

        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            //We have pressed jump so we should set 
            //our upward velocity to our jump speed
            velocity.y = jumpSpeed;

            //give the velocity to the rigid body
            physicsBody.velocity = velocity;
        }

    }

    //our own function for handling player death
    public void Kill()
    {
        //Take away a life and save that change
        livesObject.LoseLife();
        livesObject.SaveLives();

        //check if game over
        bool gameOver = livesObject.IsGameOver();

        if (gameOver == true)
        {
            //if is game over load game over scene
            SceneManager.LoadScene("GameOver");

        }
        else
        {
            //if not game over reset current level from start

            //reset the current level to restart from beginning

            //forst ask unity what the current level is
            Scene currentLevel = SceneManager.GetActiveScene();

            //second tell Unity to load current level again
            //by passing the build index of our level
            SceneManager.LoadScene(currentLevel.buildIndex);
        }

    }

}
