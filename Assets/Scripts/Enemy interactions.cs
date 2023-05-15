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

    public void FightStartCall(){
        GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().fightingScriptGO.GetComponent<FightingFunctions>().StartFight();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if(enemytype == "fireworm")
            {
                enemyObj = this.gameObject;
                eneymhp = 10;
                enemydmg = 5;
                //this.gameObject.GetComponent<EnemyMovement>().speed = 0;
                this.gameObject.GetComponent<EnemyMovement>().stopMoving = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().colEnemy = enemyObj;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyScale = new Vector3(1.93f,1.93f,1.93f);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,842,0);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(666,741,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,700,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().fighting = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().CancelAnimation();
                //Debug.Log(enemytype);
                FightStartCall();


            }
            if(enemytype == "monk")
            {
                //Debug.Log(enemytype);
                enemyObj = this.gameObject;
                eneymhp = 10;
                enemydmg = 5;
                //this.gameObject.GetComponent<EnemyMovement>().speed = 0;
                this.gameObject.GetComponent<EnemyMovement>().stopMoving = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().colEnemy = enemyObj;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyScale = new Vector3(2.3f,2.3f,2.3f);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,842,0);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(666,741,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(656,701,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().fighting = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().CancelAnimation();
                FightStartCall();

            }
            if (enemytype == "icegiant")
            {
                enemyObj = this.gameObject;
                eneymhp = 20;
                enemydmg = 10;
                //this.gameObject.GetComponent<EnemyMovement>().speed = 0;
                this.gameObject.GetComponent<EnemyMovement>().stopMoving = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().colEnemy = enemyObj;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyScale = new Vector3(2.3f,2.3f,2.3f);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,842,0);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(666,741,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(656,701,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().fighting = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().CancelAnimation();
                FightStartCall();
            }
            if (enemytype == "joebid")
            {
                //Debug.Log(enemytype);
                enemyObj = this.gameObject;
                eneymhp = 25;
                enemydmg = 10;
                //this.gameObject.GetComponent<EnemyMovement>().speed = 0;
                this.gameObject.GetComponent<EnemyMovement>().stopMoving = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().colEnemy = enemyObj;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyScale = new Vector3(2.8f,2.8f,2.8f);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,842,0);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(666,741,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,702,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().fighting = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().CancelAnimation();
                FightStartCall();

            }
            if (enemytype == "joeyen")
            {
                enemyObj = this.gameObject;
                Debug.Log(enemytype);
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
            if (enemytype == "gungleguy")
            {
                enemyObj = this.gameObject;
                Debug.Log(enemytype);
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
            if (enemytype == "fabian")
            {
                enemyObj = this.gameObject;
                Debug.Log(enemytype);
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
            if (enemytype == "jakoblaghoul")
            {
                enemyObj = this.gameObject;
                eneymhp = 50;
                enemydmg = 20;
                //this.gameObject.GetComponent<EnemyMovement>().speed = 0;
                this.gameObject.GetComponent<EnemyMovement>().stopMoving = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().colEnemy = enemyObj;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyPrevPos = transform.position;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyScale = new Vector3(2.3f,2.3f,2.3f);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(654,842,0);
                //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(666,741,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().enemyMove = new Vector3(656,703,0);
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().fighting = true;
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().CancelAnimation();
                FightStartCall();
            }
            if (enemytype == "kasei")
            {
                enemyObj = this.gameObject;
                Debug.Log(enemytype);
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
            if (enemytype == "marshall")
            {
                enemyObj = this.gameObject;
                Debug.Log(enemytype);
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
            if (enemytype == "thomas")
            {
                enemyObj = this.gameObject;
                Debug.Log(enemytype);
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
        }
    }


}
