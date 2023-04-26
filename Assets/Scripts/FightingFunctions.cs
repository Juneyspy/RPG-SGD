using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FightingFunctions : MonoBehaviour
{
    public GameObject fighitngscreen;
    public GameObject Battlepass;
    public GameObject Itemstuff;
    public GameObject StatsHolder;
    public GameObject SwordRuneHolder;
    public GameObject ArmorRuneHolder;

    public GameObject player; // move to 438,741,0 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            runaway();
        }
    }
    public void runaway()
    {
        fighitngscreen.SetActive(false);
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
