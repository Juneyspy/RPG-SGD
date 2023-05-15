using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WoodenDrops : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite openChest;
    public Sprite closedChest;
    public bool opened = false;
    public bool inInv = false;

    GameObject player;
    GameObject inventory;
    GameObject runesScreen;
    GameObject inventoryScreen;
    List<GameObject> screens;

    GameObject newItemsGrid;
    public bool takenItems = false;
    //List<Image> itemsToGet = new List<Image>();
    public List<Image> allItems = new List<Image>();
    public Sprite newItem;

    public GameObject template;
    public GameObject varsObj;

    public bool ogOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
        //newItemsGrid = player.GetComponent<PlayerScript>().newItemsGrid;
        //newItemsGrid = GameObject.Find("newitemsgrid");
        varsObj = GameObject.Find("ThisIsToGetVariables");
        newItemsGrid = varsObj.GetComponent<VariableHolder>().newItemsGrid;
        //print(newItemsGrid);
        runesScreen = player.GetComponent<PlayerScript>().runesScreen;
        //inventoryScreen = player.GetComponent<PlayerScript>().inventoryScreen;
        inventoryScreen = varsObj.GetComponent<VariableHolder>().inventoryScreen;
        //inventory = player.GetComponent<PlayerScript>().inventory;
        inventory  = varsObj.GetComponent<VariableHolder>().inventory;
        //print(inventory);
        ogOpen = GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().openedStartingChest;
        if(ogOpen && SceneManager.GetActiveScene().name == "Ms G Test"){
            spriterenderer.sprite = openChest;
            takenItems = true;
            opened = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(newItemsGrid.transform.GetChild(0).transform.childCount < 1 && newItemsGrid.transform.GetChild(1).transform.childCount < 1 
            && newItemsGrid.transform.GetChild(2).transform.childCount < 1 && newItemsGrid.transform.GetChild(3).transform.childCount < 1 && inInv){
                takenItems = true;
                GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().openedStartingChest = true;
                player.GetComponent<PlayerScript>().takenItems = true;
                player.GetComponent<PlayerScript>().paused = false;
            }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !takenItems && (!ogOpen || SceneManager.GetActiveScene().name != "Ms G Test")){
            takenItems = false;
            player.GetComponent<PlayerScript>().inChest = true;
            player.GetComponent<PlayerScript>().takenItems = false;
            player.GetComponent<PlayerScript>().CancelAnimation();
            inInv = true;
            //player.GetComponent<PlayerScript>().invOpened = true;
            closedChest = spriterenderer.sprite;
            spriterenderer.sprite = openChest;
            player.GetComponent<PlayerScript>().paused = true;
            inventory.SetActive(true);
            inventoryScreen.SetActive(true);
            varsObj.GetComponent<VariableHolder>().effectsTextHolder.SetActive(false);
            varsObj.GetComponent<VariableHolder>().newItemsArea.SetActive(true);
            
            if(SceneManager.GetActiveScene().name != "Ms G Test"){
                bool destroyed = false;
                if(!destroyed){
                    for(int i = 1; i<4; i++){
                        if(newItemsGrid.transform.GetChild(i-1).transform.childCount > 0){
                            Destroy(newItemsGrid.transform.GetChild(i-1).transform.GetChild(0).gameObject);
                        }
                    }
                }
                destroyed = true;
            }

            if(SceneManager.GetActiveScene().name != "Ms G Test"){
                int amountDropped = Random.Range(1,5);
                print(amountDropped);
                for(int i=1; i < amountDropped+1; i++){
                    int itemRNG = Random.Range(0,16);
                    newItem = varsObj.GetComponent<VariableHolder>().anyItem[itemRNG].GetComponent<Image>().sprite;
                    
                    GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<Image>().sprite = newItem;
                    temp.name = varsObj.GetComponent<VariableHolder>().anyItem[itemRNG].name; temp.tag = varsObj.GetComponent<VariableHolder>().anyItem[itemRNG].tag; temp.GetComponent<HoverTip>().tipToShow = varsObj.GetComponent<VariableHolder>().anyItem[itemRNG].GetComponent<HoverTip>().tipToShow;
                    //itemsToGet.Add(newItem);
                    temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
                }
            }
            else if(SceneManager.GetActiveScene().name == "Ms G Test" && !opened){
                //print("test");
                int amountDropped = 2;
                for(int i=1; i < amountDropped+1; i++){
                    //new item - sprite                 allitems - images
                    newItem = allItems[i-1].GetComponent<Image>().sprite;
                    //print(newItem);
                    GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<Image>().sprite = newItem;
                    temp.name = allItems[i-1].name; temp.tag = allItems[i - 1].tag; temp.GetComponent<HoverTip>().tipToShow = allItems[i - 1].GetComponent<HoverTip>().tipToShow;
                    //itemsToGet.Add(newItem);
                    temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
                }
            }
            opened = true;
        }
        else{
            print("loser");
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(!ogOpen || SceneManager.GetActiveScene().name != "Ms G Test"){
            if(other.tag == "Player" && takenItems){
                inInv = false;
                player.GetComponent<PlayerScript>().inChest = inInv;
                player.GetComponent<PlayerScript>().invOpened = false;
                inventoryScreen.SetActive(false);
                inventory.SetActive(false);
            }
            else{
                inInv = false;
                player.GetComponent<PlayerScript>().inChest = inInv;
                player.GetComponent<PlayerScript>().invOpened = false;
                inventoryScreen.SetActive(false);
                inventory.SetActive(false);
                spriterenderer.sprite = closedChest;
            }
        }
    }
}
