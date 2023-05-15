using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VariableHolder : MonoBehaviour
{
    public GameObject newItemsGrid;
    public GameObject inventory;
    public GameObject invSlotParent;
    public GameObject runesScreen;
    public GameObject inventoryScreen;
    public GameObject travelScreen;
    public GameObject journalScreen;
    public GameObject newItemsArea;
    public GameObject hotBar;
    public GameObject effectsTextHolder;
    public GameObject runeSmithScreen;
    public TMP_Text goldText;
    public GameObject pauseMenu;
    int gottenPausel = 0;
    public List<GameObject> anyItem = new List<GameObject>();
    public GameObject loseScreen;
    public GameObject winScreen;
    public bool openedStartingChest = false;
    public bool hasDied = false;
    public string lastDeathSceneName;
    public GameObject fightingScriptGO;

    /*
    runesScreen = GameObject.Find("Runes screen"); runesScreen.SetActive(false);
    inventoryScreen = GameObject.Find("Inventory screen"); inventoryScreen.SetActive(false);
    travelScreen = GameObject.Find("Travel Screen"); travelScreen.SetActive(false);
    journalScreen = GameObject.Find("Journal screen"); journalScreen.SetActive(false);
    inventory = GameObject.Find("Inventory shit"); invSlotParent = GameObject.Find("quick slots"); inventory.SetActive(false);
    */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "Ms G Test"){
            if(gottenPausel == 0){
                pauseMenu = GameObject.Find("OverworldMC").GetComponent<PlayerScript>().PauseScreen;
                fightingScriptGO = GameObject.Find("Rock Enemy").GetComponent<RockEnemy>().fightMenu;
                gottenPausel = 1;
            }
        }

        


    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.J)){
            GameObject.Find("OverworldMC").GetComponent<PlayerScript>().killedLevel2Boss = true;
            GameObject.Find("OverworldMC").transform.position = new Vector3(143.24f,93.06f,0);
        }
        else if(Input.GetKeyDown(KeyCode.K)){
            GameObject.Find("OverworldMC").GetComponent<PlayerScript>().killedLevel3Boss = true;
            GameObject.Find("OverworldMC").transform.position = new Vector3(100.44f,62.2f,0);
        }
    }
}
