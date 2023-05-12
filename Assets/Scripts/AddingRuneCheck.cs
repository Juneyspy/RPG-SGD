using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingRuneCheck : MonoBehaviour
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
            if(this.transform.parent.name == "Armor slots 1" || this.transform.parent.name == "Armor slots 2" || this.transform.parent.name == "Armor slots 3" || this.transform.parent.name == "Armor slots 4"){
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().selectedArmor.GetComponent<Armor>().armor += childObj.GetComponent<RuneStats>().hpIncrease;
            }
            else if(this.transform.parent.name == "Sword slots 1" || this.transform.parent.name == "Sword slots 2" || this.transform.parent.name == "Sword slots 3" || this.transform.parent.name == "Sword slots 4"){
                GameObject.Find("OverworldMC").GetComponent<PlayerScript>().selectedSword.GetComponent<Weapon>().damage += childObj.GetComponent<RuneStats>().dmgIncrease;
            }   
        }
    }
}
