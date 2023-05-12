using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorRuneCheck : MonoBehaviour
{
    public GameObject varsObj;
    public GameObject childObj;
    public int dmgToAdd;
    public int hpToAdd;

    // Start is called before the first frame update
    void Start()
    {
        varsObj = GameObject.Find("ThisIsToGetVariables");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.transform.childCount > 0){
            childObj = this.gameObject.transform.GetChild(0).gameObject;
            //GameObject.Find("OverworldMC").GetComponent<PlayerScript>().playerShield += childObj.GetComponent<ArmorRunes>().hpIncrease;
        }
    }
}
