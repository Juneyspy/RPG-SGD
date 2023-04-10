using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverwoldMC");
        chest = GameObject.Find("Chest - Wooden");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(chest.GetComponent<WoodenDrops>().opened){
                print("initiate fight");
            }
            else{
                print("i recommend you open the chest first");
            }
        }
    }
}
