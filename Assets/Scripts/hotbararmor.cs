using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class hotbararmor : MonoBehaviour, IDropHandler
{
    public GameObject varsObj;
    GameObject player;

    public DraggableItem activeArmor;
    public TMP_Text defence;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
        GameObject dropped = eventData.pointerDrag;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        
        if(gameObject.name == "ArmorSlot" && draggableItem.isArmor){
            draggableItem.parentAfterDrag = transform;
            activeArmor = draggableItem;
        }

        //throw new System.NotImplementedException();
        }
    }

    void Start(){
        varsObj = GameObject.Find("ThisIsToGetVariables");
        player = GameObject.Find("OverworldMC");
    }

    void FixedUpdate(){
        GameObject armorPrefab;

        if(GameObject.Find("ArmorSlot").transform.childCount > 0){
            for(int i = 1; i < varsObj.GetComponent<DontDestroyScript>().itemPrefabs.Count + 1; i ++){
                if(GameObject.Find("ArmorSlot").transform.childCount > 0){
                    if(varsObj.GetComponent<DontDestroyScript>().itemPrefabs[i-1].name == activeArmor.name){
                        armorPrefab = varsObj.GetComponent<DontDestroyScript>().itemPrefabs[i-1];
                        player.GetComponent<PlayerScript>().selectedArmor = armorPrefab;
                        defence.text = (GameObject.Find("OverworldMC").GetComponent<PlayerScript>().playerHP + armorPrefab.GetComponent<Armor>().armor).ToString();
                        print(armorPrefab.GetComponent<Armor>().armor.ToString());
                        print(GameObject.Find("OverworldMC").GetComponent<PlayerScript>().playerHP.ToString());
                        player.GetComponent<PlayerScript>().playerShield = armorPrefab.GetComponent<Armor>().armor;
                        if(player.GetComponent<PlayerScript>().fighting){
                            GameObject.Find("fightingscript").GetComponent<FightingFunctions>().hpText.text = (player.GetComponent<PlayerScript>().playerHP + player.GetComponent<PlayerScript>().playerShield).ToString();
                        }
                    }
                }
            } 
        }
        else{
            defence.text = GameObject.Find("OverworldMC").GetComponent<PlayerScript>().playerHP.ToString();
            GameObject.Find("OverworldMC").GetComponent<PlayerScript>().playerShield = 0; 
        }
    }
}
