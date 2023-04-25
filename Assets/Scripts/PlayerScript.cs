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
    public bool invOpened = false;
    public bool canOpenInv = true;
    public bool canOpenPause = true;
    public bool fighting = false;

    public GameObject newItemsGrid;
    public GameObject inventory;
    public GameObject runesScreen;
    public GameObject inventoryScreen;
    public GameObject travelScreen;
    public GameObject journalScreen;
    //public GameObject fightMenu;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on start
        //newItemsGrid = GameObject.Find("newitemarea"); 
        //fightMenu = GameObject.Find("fightscene"); fightMenu.SetActive(false);
        runesScreen = GameObject.Find("Runes screen"); runesScreen.SetActive(false);
        inventoryScreen = GameObject.Find("Inventory screen"); inventoryScreen.SetActive(false);
        travelScreen = GameObject.Find("Travel Screen"); travelScreen.SetActive(false);
        journalScreen = GameObject.Find("Journal screen"); journalScreen.SetActive(false);
        inventory = GameObject.Find("Inventory shit"); inventory.SetActive(false);     
        PauseScreen.SetActive(false);
    }

    void Update()
    {
        //Movement---------------------------------------------------------------------
        if(!paused && !fighting){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        //Get Keys--------------------------------------------------------------------
                    //pausing
        if(!paused && Input.GetKeyDown(KeyCode.Escape)){
            CancelAnimation();
            PauseScreen.SetActive(true);
            paused = true;
            inventoryScreen.SetActive(false);
            inventory.SetActive(false);  
        }
        else if(paused && Input.GetKeyDown(KeyCode.Escape)){
            paused = false;
            PauseScreen.SetActive(false);
        }
                    //inventory
        if(Input.GetKeyDown(KeyCode.E) && !invOpened){
            CancelAnimation();
            paused = true;
            invOpened = true;
            PauseScreen.SetActive(false);
            inventory.SetActive(true);
            inventoryScreen.SetActive(true);
        }
        else if((Input.GetKeyDown(KeyCode.E) && invOpened) || (Input.GetKeyDown(KeyCode.Escape) && invOpened)){
            invOpened = false;
            paused = false;
            inventoryScreen.SetActive(false);
            inventory.SetActive(false);
        }

    }

    //fix continuous moving when paused, fix closing menu with esc 


    void FixedUpdate()
    {
        // Move the player's Rigidbody2D component
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //rb.velocity = movement;
    }

    public void CancelAnimation(){
        movement.x = 0;
        movement.y = 0;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
    }
}