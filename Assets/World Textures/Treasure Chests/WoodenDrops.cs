using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodenDrops : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite openChest;
    public bool opened = false;
    public bool inInv = false;

    GameObject player;
    GameObject inventory;
    GameObject runesScreen;
    GameObject inventoryScreen;
    GameObject travelScreen;
    GameObject journalScreen;
    List<GameObject> screens;

    GameObject newItemsGrid;
    bool takenItems = false;
    List<Sprite> itemsToGet = new List<Sprite>();
    public List<Sprite> allItems = new List<Sprite>();
    public Sprite newItem;

    public GameObject template;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
        newItemsGrid = GameObject.Find("quick slots (1)"); 
        runesScreen = GameObject.Find("Runes screen"); runesScreen.SetActive(false);
        inventoryScreen = GameObject.Find("Inventory screen"); inventoryScreen.SetActive(false);
        travelScreen = GameObject.Find("Travel Screen"); travelScreen.SetActive(false);
        journalScreen = GameObject.Find("Journal screen"); journalScreen.SetActive(false);
        inventory = GameObject.Find("Inventory shit"); inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(newItemsGrid.transform.GetChild(0).transform.childCount < 1 && newItemsGrid.transform.GetChild(1).transform.childCount < 1 
            && newItemsGrid.transform.GetChild(2).transform.childCount < 1 && newItemsGrid.transform.GetChild(3).transform.childCount < 1){
                takenItems = true;
                player.GetComponent<PlayerScript>().paused = false;
            }
    }

    void fawfwa(){
        if(inInv){
            if(newItemsGrid.transform.GetChild(0).gameObject.transform){
                print("filler");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !opened){
            inInv = true;
            opened = true;
            spriterenderer.sprite = openChest;
            player.GetComponent<PlayerScript>().paused = true;

            inventory.SetActive(true);
            inventoryScreen.SetActive(true);

            int amountDropped = Random.Range(1,5);
            print(amountDropped);
            for(int i=1; i < amountDropped+1; i++){
                print(i);
                newItem = allItems[Random.Range(0,2)];
                GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                temp.GetComponent<Image>().sprite = newItem;
                itemsToGet.Add(newItem);
                //newItem.transform.parent = newItemsGrid.transform.GetChild(i-1).gameObject.transform;
                temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player" && takenItems){
            inInv = false;
            inventoryScreen.SetActive(false);
            inventory.SetActive(false);
        }
    }
}
