using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject chest;
    public GameObject fightMenu;
    public GameObject fadingGO;
    public Image fading;

    // Start is called before the first frame update
    void Start()
    {
        //fightMenu = GameObject.Find("fightingcanvas"); fightMenu.SetActive(false);
        fightMenu = GameObject.Find("fightscene"); fightMenu.SetActive(false);
        player = GameObject.Find("OverwoldMC");
        chest = GameObject.Find("Chest - Wooden");
        fadingGO = GameObject.Find("Fading");
        fading = fadingGO.GetComponent<Image>(); fading.CrossFadeAlpha(0,0.0f,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(chest.GetComponent<WoodenDrops>().opened){
                fading.CrossFadeAlpha(1,1.0f,true);
                //fightMenu.SetActive(true);
                print("initiate fight");
            }
            else{
                print("i recommend you open the chest first");
            }
        }
    }
}
