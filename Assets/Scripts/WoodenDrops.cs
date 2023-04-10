using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if(other.tag == "Player" && !opened){
            player.GetComponent<PlayerScript>().CancelAnimation();
            inInv = true;
            opened = true;
            player.GetComponent<PlayerScript>().invOpened = true;
            spriterenderer.sprite = openChest;
            player.GetComponent<PlayerScript>().paused = true;

            inventory.SetActive(true);
            inventoryScreen.SetActive(true);

            if(SceneManager.GetActiveScene().name != "Ms G Test"){

                int amountDropped = Random.Range(1,5);
                for(int i=1; i < amountDropped+1; i++){
                    newItem = allItems[Random.Range(0,2)];
                    GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<Image>().sprite = newItem;
                    //itemsToGet.Add(newItem);
                    temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
                }
            }
            else{
                int amountDropped = 2;
                for(int i=1; i < amountDropped+1; i++){
                    newItem = allItems[i-1];
                    GameObject temp = Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<Image>().sprite = newItem;
                    //itemsToGet.Add(newItem);
                    temp.transform.SetParent(newItemsGrid.transform.GetChild(i-1).gameObject.transform);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player" && takenItems){
            inInv = false;
            player.GetComponent<PlayerScript>().invOpened = false;
            inventoryScreen.SetActive(false);
            inventory.SetActive(false);
        }
    }
}
