using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyinteractions : MonoBehaviour
{
    public GameObject FightMenu;
    public string enemytype;
    public int eneymhp;
    public int enemydmg;
    public GameObject player;
    public GameObject enemyObj;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
        FightMenu = GameObject.Find("fighting sex");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if(enemytype == "fireworm")
            {
                enemyObj = this.gameObject;
                /*
                player.GetComponent<PlayerScript>().colEnemy = enemyObj;
                player.GetComponent<PlayerScript>().fighting = true;
                player.GetComponent<PlayerScript>().CancelAnimation();
                FightMenu.GetComponent<FightingFunctions>().StartFight();
                player.GetComponent<PlayerScript>().enemyScale = new Vector3(1.93f, 1.93f, 1.93f);
                player.GetComponent<PlayerScript>().enemyMove = new Vector3(-1980, -761, 0);
                player.GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                Debug.Log("hi ;3");
                */

            }
            if(enemytype == "monk")
            {
                Debug.Log("hi >;3");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "icegiant")
            {
                Debug.Log("hi >;)");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "joebid")
            {
                Debug.Log("hi ;(");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "joeyen")
            {
                Debug.Log("hi >:(");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "gungleguy")
            {
                Debug.Log("hi :(");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "fabian")
            {
                Debug.Log("hi >:3");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "jakoblaghoul")
            {
                Debug.Log("hi :3");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "kasei")
            {
                Debug.Log("hi :0");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "marshall")
            {
                Debug.Log("hi ;0");
                //FightMenu.SetActive(true);
            }
            if(enemytype == "thomas")
            {
                Debug.Log("hi >;0");
                //FightMenu.SetActive(true);
            }
        }
    }


}
