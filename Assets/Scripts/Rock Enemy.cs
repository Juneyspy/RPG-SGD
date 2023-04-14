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
    public Image finalFade;

    // Start is called before the first frame update
    void Start()
    {
        //fightMenu = GameObject.Find("fightingcanvas"); fightMenu.SetActive(false);
        fadingGO = GameObject.Find("FinalFade");
        finalFade = fadingGO.GetComponent<Image>(); finalFade.CrossFadeAlpha(0,0.0f,true);
        fadingGO = GameObject.Find("Fading");
        fading = fadingGO.GetComponent<Image>(); fading.CrossFadeAlpha(0,0.0f,true);

        fightMenu = GameObject.Find("fighting sex"); fightMenu.SetActive(false);
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
            else{
                print("i recommend you open the chest first");
            }
        }
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
    }
}
