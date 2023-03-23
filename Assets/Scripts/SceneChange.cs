using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
