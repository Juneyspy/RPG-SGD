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

    GameObject inventory;
    GameObject runesScreen;
    GameObject inventoryScreen;
    GameObject travelScreen;
    GameObject journalScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on start
        PauseScreen.SetActive(false);
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
        if(!paused && Input.GetKeyDown(KeyCode.Escape)){
            print(PauseScreen);
            PauseScreen.SetActive(true);
            paused = true;
        }
        //if(paused && Input.GetKeyDown(KeyCode.Escape)){
        //    paused = false;
        //    PauseScreen.SetActive(false);
        //}

        if(Input.GetKeyDown(KeyCode.E)){ //FIXXXXX
            runesScreen = GameObject.Find("Runes screen");
            inventoryScreen = GameObject.Find("Inventory screen");
            travelScreen = GameObject.Find("Travel Screen");
            journalScreen = GameObject.Find("Journal screen");
            inventory = GameObject.Find("Inventory shit");

            inventory.SetActive(true);
            inventoryScreen.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        // Move the player's Rigidbody2D component
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //rb.velocity = movement;
    }
}