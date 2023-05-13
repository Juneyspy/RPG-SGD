using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
//-------------------------------------------MOVEMENT------------------
    public float moveSpeed = 5f; // The speed at which the player moves
    public Rigidbody2D rb; // The player's Rigidbody2D component
    Vector2 movement;
    public Animator animator;

//-------------------------------------------Menu BS-----------------
    public GameObject PauseScreen;
    public bool paused = false;
    public bool invOpened = false;
    public bool canOpenInv = true;
    public bool canOpenPause = true;
    public bool fighting = false;
    public bool inChest = false;

    //getting inventory stuff
    public GameObject newItemsGrid;
    public GameObject inventory;
    public GameObject invSlotParent;
    public GameObject runesScreen;
    public GameObject inventoryScreen;
    public GameObject travelScreen;
    public GameObject journalScreen;
    //public GameObject fightMenu;

//-------------------------------------------FIGHTING----------------
        //detecting enemy
    public GameObject colEnemy;
    public Vector3 enemyScale;
    public Vector3 enemyMove;
    public Vector3 enemyPrevPos;
    public Collider2D enemyTriggerCol;
        //battling
    public int playerHP = 100;
    public int playerShield = 0;
    public int playerDmg = 0;
    public int goldBal = 0;
    public Sprite activeWeapon;
    public GameObject selectedSword;
    public GameObject selectedArmor;
//-------------------------------------------MISC--------------------
    public TilemapRenderer doorRender;
    public Tilemap doorMap;
    bool inHouse = false;
    GameObject varsObj;
    public bool takenItems;
    bool tpedLv2 = false;
    bool tpedLv3 = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on start
        varsObj = GameObject.Find("ThisIsToGetVariables");

        //newItemsGrid = GameObject.Find("quick slots (1)"); 
        //fightMenu = GameObject.Find("fightscene"); fightMenu.SetActive(false);
        /*if(SceneManager.GetActiveScene().name == "Ms G Test"){
            runesScreen = varsObj.GetComponent<VariableHolder>().runesScreen; runesScreen.SetActive(false);
            inventoryScreen = varsObj.GetComponent<VariableHolder>().inventoryScreen; inventoryScreen.SetActive(false);
            travelScreen = varsObj.GetComponent<VariableHolder>().travelScreen; travelScreen.SetActive(false);
            journalScreen = varsObj.GetComponent<VariableHolder>().journalScreen; journalScreen.SetActive(false);
            inventory = varsObj.GetComponent<VariableHolder>().inventory; invSlotParent = varsObj.GetComponent<VariableHolder>().invSlotParent; inventory.SetActive(false); 
            PauseScreen.SetActive(false);
        }*/
        runesScreen = varsObj.GetComponent<VariableHolder>().runesScreen; runesScreen.SetActive(false);
        inventoryScreen = varsObj.GetComponent<VariableHolder>().inventoryScreen; inventoryScreen.SetActive(false);
        travelScreen = varsObj.GetComponent<VariableHolder>().travelScreen; travelScreen.SetActive(false);
        journalScreen = varsObj.GetComponent<VariableHolder>().journalScreen; journalScreen.SetActive(false);
        inventory = varsObj.GetComponent<VariableHolder>().inventory; invSlotParent = varsObj.GetComponent<VariableHolder>().invSlotParent; inventory.SetActive(false);
        if(SceneManager.GetActiveScene().name != "Ms G Test"){
            //PauseScreen = varsObj.GetComponent<VariableHolder>().pauseMenu;
            PauseScreen = GameObject.Find("Pause setup");
        }
        PauseScreen.SetActive(false);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level 1 - Grassland Forest" && !tpedLv2){
            gameObject.transform.position = new Vector3(-5.487f, -140.4f,0);
            tpedLv2 = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Level 2 - TBT");
        }
        if(Input.GetKeyDown(KeyCode.L)){
            varsObj.GetComponent<VariableHolder>().runeSmithScreen.SetActive(true);
        }

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
        //if(!takenItems){
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
                if(fighting){
                    GameObject.Find("fightingscript").GetComponent<FightingFunctions>().swordWarning.text = " ";
                }
                if(inChest){
                    invOpened = false;
                    paused = false;
                    inventoryScreen.SetActive(false);
                    inventory.SetActive(false);
                }
                else{
                    CancelAnimation();
                    paused = true;
                    invOpened = true;
                    PauseScreen.SetActive(false);
                    inventory.SetActive(true);
                    inventoryScreen.SetActive(true);
                    varsObj.GetComponent<VariableHolder>().goldText.text = goldBal.ToString();
                    if(!inChest){
                        GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().newItemsArea.SetActive(false);
                        GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().effectsTextHolder.SetActive(true);
                    }
                }
            }
            else if((Input.GetKeyDown(KeyCode.E) && invOpened) || (Input.GetKeyDown(KeyCode.Escape) && invOpened)){
                invOpened = false;
                paused = false;
                inventoryScreen.SetActive(false);
                inventory.SetActive(false);
            }
       // }
    }

    void FixedUpdate()
    {
        // Move the player's Rigidbody2D component
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //rb.velocity = movement;
        //activeWeapon = invSlotParent.transform.GetChild(0).gameObject.transform;
    }

    public void CancelAnimation(){
        movement.x = 0;
        movement.y = 0;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Next Level Trigger")
        {
            SceneManager.LoadScene("Level 1 - Grassland Forest");
        }

        if(other.gameObject.tag == "DoorTrigger"){
            if(!inHouse){
                doorRender.enabled = false;
                inHouse = true;
            }
            else{
                doorRender.enabled = true;
                inHouse = false;
            }
        }
    }
}