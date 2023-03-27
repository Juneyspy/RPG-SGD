using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TextMeshProUGUI header;

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

    public void HandleInputData(int val)
    {
        if (val == 0){
            textchange.text = "kys";
            header.text = "get good";
        }

        if (val == 1)
        {
            textchange.text = "kys";
            header.text = "gameplay";
        }

        if (val == 2)
        {
            textchange.text = "kys";
            header.text = "crime system";
        }

        if (val == 3)
        {
            textchange.text = "kys";
            header.text = "NPC";
        }

        if (val == 4)
        {
            textchange.text = "kys";
            header.text = "Conditions";
        }

        if (val == 5)
        {
            textchange.text = "kys";
            header.text = "Support items";
        }
    }

}
