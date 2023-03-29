using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public GameObject startscreen;
    public GameObject mainmenu;
    public GameObject title;
    public GameObject notice;
    public Animator noticeanimation;
    public GameObject NewText;
    public GameObject OverText1;
    public GameObject OverText2;
    public GameObject OverText3;
    public GameObject OverText4;
    public GameObject Load;
    public GameObject NewGame;
    public GameObject Help;
    public GameObject Controls;
    public GameObject HowToPlay;
    public GameObject Credits;

    public TextMeshProUGUI textchange;
    //textchange.GetComponent<revealtext>().RevealText();
    public TextMeshProUGUI header;
    public TextMeshProUGUI finaltext;

    public GameObject finalholder;
    public GameObject textholder;

    public TMP_Dropdown gamelist;

    public Coroutine sc;

    public int backcheck;

    public Animator herobrine;
    public Animator Hand;

    //private Sprite newGameSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void start()
    {
        startscreen.SetActive(false);
        mainmenu.SetActive(true);
    }
    public void StartTextOff()
    {
        //title.SetActive(false);
        //notice.SetActive(false);
        noticeanimation.SetBool("remove text", true);
        NewText.SetActive(true);
        Invoke("SetInactive", 5.0f);
        //newGameSprite = NewText.gameObject.transform.GetChild(0).GetComponent<Button>.HighlightedSprite;
    }

    public void herobrinespawn()
    {
        herobrine.SetBool("enlarge", true);
    }

    void SetInactive()
    {
        OverText1.SetActive(false);
        OverText2.SetActive(false);
        OverText3.SetActive(false);
        OverText4.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGameScreen()
    {
        startscreen.SetActive(false);
        NewGame.SetActive(true);
    }
    public void LoadScreen()
    {
        startscreen.SetActive(false);
        Load.SetActive(true);
    }
    public void HelpScreen()
    {
        Help.SetActive(true);
        startscreen.SetActive(false);
    }

    public void Backtohome()
    {
        Load.SetActive(false);
        Help.SetActive(false);
        NewGame.SetActive(false);
        notice.SetActive(false);
        OverText1.SetActive(true);
        OverText2.SetActive(true);
        OverText3.SetActive(true);
        OverText4.SetActive(true);
        startscreen.SetActive(true);
        Invoke("SetInactive", 5.0f);
    }

    public void ControlScreen()
    {
        Help.SetActive(false);
        Controls.SetActive(true);
    }

    public void HowToPlayScreen()
    {
        Help.SetActive(false);
        HowToPlay.SetActive(true);
        //textholder.SetActive(true);
        //finalholder.SetActive(false);
        textholder.SetActive(true);
        finalholder.SetActive(false);
        if (backcheck > 0)
        {
            clickandload();
            textholder.SetActive(false);
            finalholder.SetActive(true);
        }
    }

    public void CreditScreen()
    {
        Credits.SetActive(true);
        Help.SetActive(false);
    }

    public void BackToHelp()
    {
        Help.SetActive(true);
        Credits.SetActive(false);
        HowToPlay.SetActive(false);
        Controls.SetActive(false);
    }

    public void BackFromBasics()
    {
        backcheck++;
        HowToPlay.SetActive(false);
        Help.SetActive(true);
    }

    public void HandleInputData(int val)
    {
        textchange.GetComponent<revealtext>().clicked = false;
        print("handleinput");
        StopCoroutine(textchange.GetComponent<revealtext>().startedCoroutine);
        textholder.SetActive(true);
        finalholder.SetActive(false);
        if (gamelist.value == 0){
            val = 0;
            gamelist.value = 0;
            textchange.text = "Welcome, in this area you will learn the basics of the game and its systems. If you want to learn about the games' different systems and functions, then click on the dropdown to the left of this screen.  ";
            header.text = "Welcome";
            sc = StartCoroutine(textchange.GetComponent<revealtext>().RevealText());
            textchange.GetComponent<revealtext>().startedCoroutine = sc;
        }

        if (gamelist.value == 1)
        {
            val = 1;
            gamelist.value = 1;
            textchange.text = "This game's gameplay is quite simple, you have multiple options that you can choose from while in combat, such as: defend, run, item, and attack. If you choose to attack, it will lead to another menu asking what move you want to use. Outside of fighting, you can move around the world and talk to other characters to continue your journey.";
            header.text = "Gameplay";
            sc = StartCoroutine(textchange.GetComponent<revealtext>().RevealText());
            textchange.GetComponent<revealtext>().startedCoroutine = sc;
        }

        if (gamelist.value == 2)
        {
            val = 2;
            gamelist.value = 2;
            textchange.text = "The crime system is a feature that watches and counts your crimes. This includes actions like: killing the innocent, stealing, arson, etc. The more you commit, the more active the military will become, and after you reach a certain threshold and enter a town, you get arrested immediately and must find a way out of prison. ";
            header.text = "Crime system";
            sc = StartCoroutine(textchange.GetComponent<revealtext>().RevealText());
            textchange.GetComponent<revealtext>().startedCoroutine = sc;
        }

        if (gamelist.value == 3)
        {
            val = 3;
            gamelist.value = 3;
            textchange.text = "The NPCs in this game are simple but will adapt to what you do. At each area you go to you can find NPCs that inform you or give you hints about what to do next. They adapt when you commit more crimes / get arrested, the NPCs will have different lines condemning you and merchants will raise their prices sharply from before. ";
            header.text = "NPC";
            sc = StartCoroutine(textchange.GetComponent<revealtext>().RevealText());
            textchange.GetComponent<revealtext>().startedCoroutine = sc;
        }

        if (gamelist.value == 4)
        {
            val = 4;
            gamelist.value = 4;
            textchange.text = "Fights in this game can become more complicated with conditions. By applying different effects to your weapon, it can deal different types of damage or status effects. for example: a fire imbued sword will do fire damage and ice will slow your enemy.";
            header.text = "Conditions";
            sc = StartCoroutine(textchange.GetComponent<revealtext>().RevealText());
            textchange.GetComponent<revealtext>().startedCoroutine = sc;
        }

        if (gamelist.value == 5)
        {
            val = 5;
            gamelist.value = 5;
            textchange.text = "To combat condtions against the player you have the chance to select item in the fight and find the appropiate item to support yourself. An example of a few itmes is potions, fire burn, cure sleep, etc.";
            header.text = "Support items";
            sc = StartCoroutine(textchange.GetComponent<revealtext>().RevealText());
            textchange.GetComponent<revealtext>().startedCoroutine = sc;
        }
    }

    public void clickandload()
    {
        textchange.GetComponent<revealtext>().clicked = true;
        textholder.SetActive(false);
        finalholder.SetActive(true);
        if (gamelist.value == 0)
        {
            gamelist.value = 0;
            finaltext.text = "Welcome, In this area you will learn the basics of the game and its systems. If you want to learn about the games different systems and functions, then click on the dropdown to the left of this screen. ";
            header.text = "Welcome";

        }

        if (gamelist.value == 1)
        {
            gamelist.value = 1;
            finaltext.text = "This game's gameplay is quite simple, you have multiple options that you can choose from while in combat, such as: defend, run, item, and attack. If you choose to attack, it will lead to another menu asking what move you want to use. Outside of fighting, you can move around the world and talk to other characters to continue your journey.";
            header.text = "Gameplay";
        }

        if (gamelist.value == 2)
        {
            gamelist.value = 2;
            finaltext.text = "The crime system is a feature that watches and counts your crimes. This includes actions like: killing the innocent, stealing, arson, etc. The more you commit, the more active the military will become, and after you reach a certain threshold and enter a town, you get arrested immediately and must find a way out of prison. ";
            header.text = "Crime system";
        }

        if (gamelist.value == 3)
        {
            gamelist.value = 3;
            finaltext.text = "The NPCs in this game are simple but will adapt to what you do. At each area you go to you can find NPCs that inform you or give you hints about what to do next. They adapt when you commit more crimes / get arrested, the NPCs will have different lines condemning you and merchants will raise their prices sharply from before. ";
            header.text = "NPC";
        }

        if (gamelist.value == 4)
        {
            gamelist.value = 4;
            finaltext.text = "Fights in this game can become more complicated with conditions. By applying different effects to your weapon, it can deal different types of damage or status effects. for example: a fire imbued sword will do fire damage and ice will slow your enemy.";
            header.text = "Conditions";
        }

        if (gamelist.value == 5)
        {
            gamelist.value = 5;
            finaltext.text = "To combat condtions against the player you have the chance to select item in the fight and find the appropiate item to support yourself. An example of a few itmes is potions, fire burn, cure sleep, etc.";
            header.text = "Support items";
        }
    }

}
