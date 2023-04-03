using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSceneClose : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            gameObject.SetActive(false);
            player.GetComponent<PlayerScript>().paused = false;
        }
    }

    public void Resume(){
        gameObject.SetActive(false);
        player.GetComponent<PlayerScript>().paused = false; 
    }

    public void Save(){
        //save the currect slot
    }

    public void Settings(){
        //open settings menu
    }

    public void BackToMenu(){
        //return to main menu
    }

    public void Quit(){
        Application.Quit();
    }

}
