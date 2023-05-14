using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreens : MonoBehaviour
{
    public GameObject Winscreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome()
    {
        GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().winScreen.SetActive(false);
        GameObject.Find("ThisIsToGetVariables").GetComponent<VariableHolder>().loseScreen.SetActive(false);
        GameObject.Find("fightingscript").GetComponent<FightingFunctions>().fightMenu.SetActive(false);
        SceneManager.LoadScene("FrontEnd");
    }

    public void Respawn(){
        if(SceneManager.GetActiveScene().name == "Level 1 - Grassland Forest"){
            GameObject.Find("OverworldMC").transform.position = new Vector3(-5.487f, -140.4f,0);
            gameObject.SetActive(false);
        }
        else{
            GameObject.Find("OverworldMC").transform.position = new Vector3(-27.15f, -123.75f,-0.01098486f);
            gameObject.SetActive(false);
        }
    }
}
