using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    public Rigidbody2D rb; // The player's Rigidbody2D component
    Vector2 movement;
    public Animator animator;

    public GameObject PauseScreen;
    public bool paused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on start
    }

    void Update()
    {
        //Movement---------------------------------------------------------------------
        if(!paused){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        //Get Keys--------------------------------------------------------------------
        if(Input.GetKeyDown(KeyCode.Escape)){
            print(PauseScreen);
            PauseScreen.SetActive(true);
            paused = true;
        }

    }

    void FixedUpdate()
    {
        // Move the player's Rigidbody2D component
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //rb.velocity = movement;
    }
}