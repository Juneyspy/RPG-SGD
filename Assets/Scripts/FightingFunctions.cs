using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingFunctions : MonoBehaviour
{
    public GameObject fighitngscreen;
    public GameObject Battlepass;
    public GameObject Itemstuff;

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
    }
}
