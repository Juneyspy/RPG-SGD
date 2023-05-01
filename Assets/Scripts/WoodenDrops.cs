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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
        newItemsGrid = player.GetComponent<PlayerScript>().newItemsGrid;
        runesScreen = player.GetComponent<PlayerScript>().runesScreen;
        inventoryScreen = player.GetComponent<PlayerScript>().inventoryScreen;
        inventory = player.GetComponent<PlayerScript>().inventory;
    }

    // Update is called once per frame
    void Update()
    {
        if(newItemsGrid.transform.GetChild(0).transform.childCount < 1 && newItemsGrid.transform.GetChild(1).transform.childCount < 1 
            && newItemsGrid.transform.GetChild(2).transform.childCount < 1 && newItemsGrid.transform.GetChild(3).transform.childCount < 1 && inInv){
                takenItems = true;
                player.GetComponent<PlayerScript>().paused = false;
            }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !takenItems){
            player.GetComponent<PlayerScript>().CancelAnimation();
            inInv = true;
            //player.GetComponent<PlayerScript>().invOpened = true;
            closedChest = spriterenderer.sprite;
            spriterenderer.sprite = openChest;
            player.GetComponent<PlayerScript>().paused = true;

            inventory.SetActive(true);
            inventoryScreen.SetActive(true);

            if(SceneManager.GetActiveScene().name != "Ms G Test"){
                int amountDropped = Random.Range(1,5);
                for(int i=1; i < amountDropped+1; i++){
                    newItem = allItems[Random.Range(0,2)].sprite;
                    GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<Image>().sprite = newItem;
                    //itemsToGet.Add(newItem);
                    temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
                }
            }
            else if(SceneManager.GetActiveScene().name == "Ms G Test" && !opened){
                print("test");
                int amountDropped = 2;
                for(int i=1; i < amountDropped+1; i++){
                    newItem = allItems[i-1].sprite;
                    GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<Image>().sprite = newItem;
                    //itemsToGet.Add(newItem);
                    temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
                }
            }
            opened = true;
        }
    }//FIX THE SPRITE TO IMAGE CONVERSIONS

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player" && takenItems){
            inInv = false;
            player.GetComponent<PlayerScript>().invOpened = false;
            inventoryScreen.SetActive(false);
            inventory.SetActive(false);
        }
        else{
            inInv = false;
            player.GetComponent<PlayerScript>().invOpened = false;
            inventoryScreen.SetActive(false);
            inventory.SetActive(false);
            spriterenderer.sprite = closedChest;
        }
    }
}
