using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject chest;
    public GameObject enemyObj;
    public GameObject fightMenu;

    public int rockHP = 5;
    public int rockDmg = 5;

    // Start is called before the first frame update
    void Start()
    {
        //fightMenu = GameObject.Find("fightingscript");
        //print(fightMenu);
        //fightMenu = GameObject.Find("fightingcanvas"); fightMenu.SetActive(false)
        player = GameObject.Find("OverworldMC");
        chest = GameObject.Find("Chest - Wooden");
        enemyObj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(chest.GetComponent<WoodenDrops>().takenItems){
                player.GetComponent<PlayerScript>().colEnemy = enemyObj;
                player.GetComponent<PlayerScript>().fighting = true;
                player.GetComponent<PlayerScript>().CancelAnimation();
                fightMenu.GetComponent<FightingFunctions>().StartFight();
                player.GetComponent<PlayerScript>().enemyScale = new Vector3(1.93f,1.93f,1.93f);
                player.GetComponent<PlayerScript>().enemyMove = new Vector3(-1980,-761,0);
                player.GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                //player.GetComponent<PlayerScript>().enemyTriggerCol = GetComponent<Collider>(); //put enmty obj  below rock and set that to be colider in order tot ake trigger collider from rokc

            }
            else{
                print("i recommend you open the chest first");
            }
        }
    }
}
