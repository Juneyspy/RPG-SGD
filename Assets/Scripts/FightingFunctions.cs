using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject totalInv;
    public GameObject inv;

    public TextMeshProUGUI item1;
    public TextMeshProUGUI item2;
    public TextMeshProUGUI item3;
    public TextMeshProUGUI item4;
    public TextMeshProUGUI item5;

    public GameObject buttonholder1;
    public GameObject buttonholder2;
    public GameObject buttonholder3;
    public GameObject buttonholder4;
    public GameObject buttonholder5;
    string nameholder;
    public int amountholder;
    public GameObject Safteynet;
    public int runs;

    public TMP_Text hpText;
    public TMP_Text swordWarning;
    public TMP_Text enemyHPText;
    public int enemyHP;
    public Image enemyAttOverlay;
    public bool canAttack = true;

    //public PlayerScript playerScript;
    public List<GameObject> potionsList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        buttonholder1.SetActive(true);
        buttonholder2.SetActive(true);
        buttonholder3.SetActive(true);
        buttonholder4.SetActive(true);
        buttonholder5.SetActive(true);
        if (SceneManager.GetActiveScene().name != "FrontEnd")
        {
            fadingGO = GameObject.Find("Fading");
            fading = fadingGO.GetComponent<Image>(); fading.CrossFadeAlpha(0, 0.0f, true);
            fadingGO = GameObject.Find("FinalFade");
            finalFade = fadingGO.GetComponent<Image>(); finalFade.CrossFadeAlpha(0, 0.0f, true);
            fightMenu = GameObject.Find("fighitng");
            cam = GameObject.Find("Main Camera");
            fightMenu.SetActive(false);
            enemyAttOverlay.CrossFadeAlpha(0,0.0f,true);
        }
        player = GameObject.Find("OverworldMC");
        //totalInv = GameObject.Find("quick slots");
        //inv = GameObject.Find("inventory holder"); inv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //totalInv = GameObject.Find("quick slots");
        //inv = GameObject.Find("inventory holder");
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
        hpText.text = (player.GetComponent<PlayerScript>().playerHP + player.GetComponent<PlayerScript>().playerShield).ToString();
        print("initiate fight");
        if(SceneManager.GetActiveScene().name == "Ms G Test"){
            enemyHPText.text = "Enemy HP: " + player.GetComponent<PlayerScript>().colEnemy.GetComponent<RockEnemy>().rockHP.ToString();
            enemyHP = player.GetComponent<PlayerScript>().colEnemy.GetComponent<RockEnemy>().rockHP;
        }        //PUT IN ELSE{GET COMPONENT BASICENEMYSCRIPT HP AND ANOTHER FOR BOSS HP SCRIPTS}

        if(player.GetComponent<PlayerScript>().playerDmg == 0){
            swordWarning.text = "Make sure to equip your sword... (E)";
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
        cam.GetComponent<CameraScript>().following = false;
        cam.transform.position = cam.GetComponent<CameraScript>().battleLoc;
        player.GetComponent<PlayerScript>().colEnemy.transform.localScale += player.GetComponent<PlayerScript>().enemyScale;
        player.GetComponent<PlayerScript>().colEnemy.transform.position = player.GetComponent<PlayerScript>().enemyMove;
    }

    //THIS IS WHERE HELL HAPPENS RAAAAAAAAAAAAAAAAAAAAAAAAAAA
    public void LightAttack(){
        Battlepass.SetActive(false);
        if(canAttack){
            canAttack = false;
            int dmgToDo = player.GetComponent<PlayerScript>().playerDmg;
            enemyHP -= dmgToDo;
            enemyHPText.text = "Enemy HP: " + enemyHP.ToString();
            if(enemyHP > 0){
                Invoke("EnemyAttack", 1.4f);
            }
            Invoke("ReenableAttack",2.4f);
            GameOverCheck(enemyHP);
        }
    }

    public void HeavyAttack(){
        Battlepass.SetActive(false);
        if(canAttack){
            canAttack = false;
            int dmgToDo = player.GetComponent<PlayerScript>().playerDmg * 2;
            enemyHP -= dmgToDo;
            enemyHPText.text = "Enemy HP: " + enemyHP.ToString();
            if(enemyHP > 0){
                Invoke("EnemyAttack", 1.4f);
            }
            Invoke("ReenableAttack",2.4f);
            GameOverCheck(enemyHP);
        }
    }

    void ReenableAttack(){
        canAttack = true;
    }

    void HidingRed(){
        enemyAttOverlay.CrossFadeAlpha(0,0.6f,true);
    }
    public void EnemyAttack(){
        enemyAttOverlay.CrossFadeAlpha(1,0.3f,true);
        Invoke("HidingRed",0.3f);
        if(SceneManager.GetActiveScene().name == "Ms G Test"){
            if(player.GetComponent<PlayerScript>().playerShield > 1){
                player.GetComponent<PlayerScript>().playerShield -= player.GetComponent<PlayerScript>().colEnemy.GetComponent<RockEnemy>().rockDmg;
                if(player.GetComponent<PlayerScript>().playerShield < 0){
                    player.GetComponent<PlayerScript>().playerHP -= player.GetComponent<PlayerScript>().playerShield * -1;
                    player.GetComponent<PlayerScript>().playerShield = 0;
                }
            }
            else{
                player.GetComponent<PlayerScript>().playerHP -= player.GetComponent<PlayerScript>().colEnemy.GetComponent<RockEnemy>().rockDmg;
            }
        }

        hpText.text = (player.GetComponent<PlayerScript>().playerHP + player.GetComponent<PlayerScript>().playerShield).ToString();
    }

    public void GameOverCheck(int opHealth){
        if(opHealth <= 0){
            cam.GetComponent<CameraScript>().following = true;

            int goldToGive = Random.Range(1,4);
            player.GetComponent<PlayerScript>().goldBal += goldToGive;

            Destroy(player.GetComponent<PlayerScript>().colEnemy);
            player.GetComponent<PlayerScript>().fighting = false;
        }

        if(player.GetComponent<PlayerScript>().playerHP <= 0){
            print("dead");
            //MAKE AN ACTUALLY DYING THING
        }

        if(opHealth <= 0 || player.GetComponent<PlayerScript>().playerHP <= 0){
            enemyHPText.enabled = false;
        }
    }

    public void Defend(){

    }


    public void runaway()
    {
        fighitngscreen.SetActive(false);
        cam.GetComponent<CameraScript>().following = true;
        player.GetComponent<PlayerScript>().fighting = false;
        player.GetComponent<PlayerScript>().colEnemy.transform.position = player.GetComponent<PlayerScript>().enemyPrevPos;
        player.GetComponent<PlayerScript>().colEnemy.transform.localScale -= player.GetComponent<PlayerScript>().enemyScale;
        //player.GetComponent<PlayerScript>().colEnemy.transform.GetChild(0).gameObject.GetComponent<>
        player.GetComponent<PlayerScript>().colEnemy.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("EnableCollider",4.0f);
    }
    void EnableCollider(){
        player.GetComponent<PlayerScript>().colEnemy.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void battlescreen()
    {
        Battlepass.SetActive(true);
    }

    public void itemcheck()
    {
        if (item1.text == "0")
        {
            buttonholder1.SetActive(false);
        }

        if (item2.text == "0")
        {
            Debug.Log("hi ;3");
            buttonholder2.SetActive(false);
        }

        if (item3.text == "0")
        {
            buttonholder3.SetActive(false);
        }

        if (item4.text == "0")
        {
            buttonholder4.SetActive(false);
        }

        if (item5.text == "0")
        {
            buttonholder5.SetActive(false);
        }

    }

    public void itemscreen()
    {
        totalInv = GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().invSlotParent;;
        inv = GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().inventory;
        inv.SetActive(true);
        Itemstuff.SetActive(true);
        Safteynet.SetActive(true);
        runs++;
        Debug.Log(runs);
        if(runs < 1)
        {

        }
        for (int i = 1; i < 36; i++)
        {
            //print(i);
            if(totalInv.transform.GetChild(i-1).gameObject.transform.childCount > 0)
            {
                nameholder = totalInv.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                if (nameholder == "Potion")
                {
                    if (runs == 1)
                    {
                        buttonholder1.SetActive(true);
                        int tempInt10;
                        //Int32.TryParse(item1.text, out tempInt);
                        tempInt10 = int.Parse(item1.text);
                        tempInt10++;
                        item1.text = tempInt10.ToString();

                    }
                }

                if (nameholder == "Big Potion")
                {
                    if (runs == 1)
                    {
                        buttonholder2.SetActive(true);
                        int tempInt9;
                        //Int32.TryParse(item1.text, out tempInt);
                        tempInt9 = int.Parse(item2.text);
                        tempInt9++;
                        item2.text = tempInt9.ToString();

                    }
                }

                if (nameholder == "Antidote")
                {
                    if (runs == 1)
                    {
                        buttonholder3.SetActive(true);
                        int tempInt8;
                        //Int32.TryParse(item1.text, out tempInt);
                        tempInt8 = int.Parse(item3.text);
                        tempInt8++;
                        item3.text = tempInt8.ToString();

                    }
                }

                if (nameholder == "The Big Fix")
                {
                    if (runs == 1)
                    {

                        buttonholder4.SetActive(true);
                        int tempInt7;
                        //Int32.TryParse(item1.text, out tempInt);
                        tempInt7 = int.Parse(item4.text);
                        tempInt7++;
                        item4.text = tempInt7.ToString();
                    }
                }

                if (nameholder == "Bath Salts")
                {
                    if (runs == 1)
                    {
                        buttonholder5.SetActive(true);
                        int tempInt6;
                        //Int32.TryParse(item1.text, out tempInt);
                        tempInt6 = int.Parse(item5.text);
                        tempInt6++;
                        item5.text = tempInt6.ToString();

                    }
                }

                if (totalInv.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.transform.tag == "Item")
                {
                    /*
 
                    nameholder = totalInv.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                    if(nameholder == "Potion")
                    {
                        Debug.Log("cum");
                    }

                    if(nameholder == "Big Potion")
                    {
                        Debug.Log("hot");
                    }
                    switch (i)
                    {
                        case 0:
                            Debug.Log("uh oh");
                            break;
                        case 1:
                            if (nameholder == "Potion")
                            {
                                Debug.Log("hi 1");
                            }
                            Debug.Log("guy");
                            int tempInt10;
                            //Int32.TryParse(item1.text, out tempInt);
                            tempInt10 = int.Parse(item1.text);
                            print(tempInt10);
                            tempInt10++;
                            item1.text = tempInt10.ToString();
                            break;
                        case 2:
                            if (nameholder == "Big Potion")
                            {
                                Debug.Log("hi 2");
                            }
                            Debug.Log("guy");
                            int tempInt9;
                            //Int32.TryParse(item1.text, out tempInt);
                            tempInt9 = int.Parse(item2.text);
                            print(tempInt9);
                            tempInt9++;
                            item2.text = tempInt9.ToString();
                            break;
                        case 3:
                            if (nameholder == "Antidote")
                            {
                                Debug.Log("hi 3");
                            }
                            Debug.Log("guy");
                            int tempInt8;
                            //Int32.TryParse(item1.text, out tempInt);
                            tempInt8 = int.Parse(item3.text);
                            print(tempInt8);
                            tempInt8++;
                            item3.text = tempInt8.ToString();
                            break;
                        case 4:
                            if (nameholder == "The Big Fix")
                            {
                                Debug.Log("hi 4");
                            }
                            Debug.Log("guy");
                            int tempInt7;
                            //Int32.TryParse(item1.text, out tempInt);
                            tempInt7 = int.Parse(item4.text);
                            print(tempInt7);
                            tempInt7++;
                            item4.text = tempInt7.ToString();
                            break;
                        case 5:
                            if (nameholder == "Bath Salts")
                            {
                                Debug.Log("hi 5");
                            }
                            Debug.Log("guy");
                            int tempInt6;
                            //Int32.TryParse(item1.text, out tempInt);
                            tempInt6 = int.Parse(item5.text);
                            print(tempInt6);
                            tempInt6++;
                            item5.text = tempInt6.ToString();
                            break;
                        case 6:
                            Debug.Log("wah-wah");
                            break;
                    }
                    */


                    //item1.text = nameholder;
                    //print("waaaa");
                }
            }
        }
        
        inv.SetActive(false);
        /*
        GameObject trash = inv.transform.GetChild(35).gameObject;
        if(player.GetComponent<PlayerScript>().invOpened){
            if (trash.transform.childCount > 0){
                Destroy(trash.transform.GetChild(0).gameObject);}
            }
        */
    }
    public void backtofightscreen()
    {
        Battlepass.SetActive(false);
        Itemstuff.SetActive(false);
        StatsHolder.SetActive(false);
        ArmorRuneHolder.SetActive(false);
        SwordRuneHolder.SetActive(false);
        Safteynet.SetActive(false);
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

        if (item1.text == "1")
        {
            Destroy(ByeBye.gameObject);
        }
        else
        {
            int tempInt;
            //Int32.TryParse(item1.text, out tempInt);
            tempInt = int.Parse(item1.text);
            tempInt--;
            item1.text = tempInt.ToString();
        }

        for(int l = 1; l < potionsList.Count-1; l++){
            if(potionsList[l-1].name == ButtonName){
                player.GetComponent<PlayerScript>().playerHP += potionsList[l-1].GetComponent<PotionStuff>().hpToGive;
                if(player.GetComponent<PlayerScript>().playerHP > 100){
                    player.GetComponent<PlayerScript>().playerHP = 100;
                }
            }
        }

        // make code here that uses the item and applys its effects.
        //Destroy(ByeBye.gameObject);
    }
    public void PrintItemUse2()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        GameObject ByeBye = GameObject.Find(ButtonName);
        if (item2.text == "1")
        {
            Destroy(ByeBye.gameObject);
        }
        else
        {
            int tempInt1;
            //Int32.TryParse(item1.text, out tempInt);
            tempInt1 = int.Parse(item2.text);
            print(tempInt1);
            tempInt1--;
            item2.text = tempInt1.ToString();
        }
    }

    public void PrintItemUse3()
    {

        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        GameObject ByeBye = GameObject.Find(ButtonName);

        if (item3.text == "1")
        {
            Destroy(ByeBye.gameObject);
        }
        else
        {
            int tempInt2;
            //Int32.TryParse(item1.text, out tempInt);
            tempInt2 = int.Parse(item3.text);
            tempInt2--;
            item3.text = tempInt2.ToString();
        }

    }

    public void PrintItemUse4()
    {

        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        GameObject ByeBye = GameObject.Find(ButtonName);
        if (item4.text == "1")
        {
            Destroy(ByeBye.gameObject);
        }
        else
        {
            int tempInt3;
            //Int32.TryParse(item1.text, out tempInt);
            tempInt3 = int.Parse(item4.text);
            tempInt3--;
            item4.text = tempInt3.ToString();
        }

    }

    public void PrintItemUse5()
    {

        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        GameObject ByeBye = GameObject.Find(ButtonName);
        if (item5.text == "1")
        {
            Destroy(ByeBye.gameObject);
        }
        else
        {
            int tempInt5;
            //Int32.TryParse(item1.text, out tempInt);
            tempInt5 = int.Parse(item5.text);
            tempInt5--;
            item5.text = tempInt5.ToString();
        }
    }
    

}
