using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightingFunctions : MonoBehaviour
{
    public GameObject fighitngscreen;
    public GameObject Battlepass;
    public GameObject Itemstuff;
    public GameObject StatsHolder;
    public GameObject SwordRuneHolder;
    public GameObject ArmorRuneHolder;

    public GameObject player; // move to 438,741,0
    public GameObject bigCharacter;
    public GameObject fadingGO;
    public Image fading;
    public Image finalFade;
    public GameObject fightMenu;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        fadingGO = GameObject.Find("Fading");
        fading = fadingGO.GetComponent<Image>(); fading.CrossFadeAlpha(0,0.0f,true);
        fadingGO = GameObject.Find("FinalFade");
        finalFade = fadingGO.GetComponent<Image>(); finalFade.CrossFadeAlpha(0,0.0f,true);
        fightMenu = GameObject.Find("fighting");
        cam = GameObject.Find("Main Camera");
        fightMenu.SetActive(false);
        player = GameObject.Find("OverworldMC");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            runaway();
        }
    }

    public void StartFight(){
        fading.CrossFadeAlpha(1,.2f,true);
        Invoke("fadeOut",.2f);
        Invoke("fadeIn",.4f);
        Invoke("fadeOut",.6f);
        Invoke("fadeIn",.8f);
        Invoke("TurnOnFighting",.8f);
        Invoke("fadeOutFinal",1.0f);
        Invoke("fadeOut",1.0f);
        print("initiate fight");
    }
    public void fadeOut(){
        fading.CrossFadeAlpha(0,.2f,true);
    }
    public void fadeIn(){
        fading.CrossFadeAlpha(1,.2f,true);
    }
    public void TurnOnFighting(){
        fightMenu.SetActive(true);
        finalFade.CrossFadeAlpha(1,0.0f,true);
    }
    public void fadeOutFinal(){
        finalFade.CrossFadeAlpha(0,.2f,true);
        cam.GetComponent<CameraScript>().following = false;
        cam.transform.position = cam.GetComponent<CameraScript>().battleLoc;
        player.GetComponent<PlayerScript>().colEnemy.transform.localScale += player.GetComponent<PlayerScript>().enemyScale;
        player.GetComponent<PlayerScript>().colEnemy.transform.position = player.GetComponent<PlayerScript>().enemyMove;
    }


    public void runaway()
    {
        fighitngscreen.SetActive(false);
        cam.GetComponent<CameraScript>().following = true;
        player.GetComponent<PlayerScript>().fighting = false;
        player.GetComponent<PlayerScript>().colEnemy.transform.position = player.GetComponent<PlayerScript>().enemyPrevPos;
        player.GetComponent<PlayerScript>().colEnemy.transform.localScale -= player.GetComponent<PlayerScript>().enemyScale;
    }
    public void battlescreen()
    {
        Battlepass.SetActive(true);
    }
    public void itemscreen()
    {
        Itemstuff.SetActive(true);
    }
    public void backtofightscreen()
    {
        Battlepass.SetActive(false);
        Itemstuff.SetActive(false);
        StatsHolder.SetActive(false);
        ArmorRuneHolder.SetActive(false);
        SwordRuneHolder.SetActive(false);
    }
    public void StatsScreen()
    {
        StatsHolder.SetActive(true);
        ArmorRuneHolder.SetActive(false);
        SwordRuneHolder.SetActive(false);
    }
    public void ArmorON()
    {
        ArmorRuneHolder.SetActive(true);
        SwordRuneHolder.SetActive(false); 
        StatsHolder.SetActive(false);
    }
    public void SwordON()
    {
        SwordRuneHolder.SetActive(true);
        StatsHolder.SetActive(false);
        ArmorRuneHolder.SetActive(false);
    }
    public void PrintItemUse()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        GameObject ByeBye = GameObject.Find(ButtonName);
        // make code here that uses the item and applys its effects.
        Destroy(ByeBye.gameObject);
    }

}
