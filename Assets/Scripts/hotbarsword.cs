using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class hotbarsword : MonoBehaviour, IDropHandler
{
    public GameObject varsObj;
    GameObject player;

    public DraggableItem activeSword;
    public TMP_Text strength;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
        GameObject dropped = eventData.pointerDrag;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        
        if(gameObject.name == "SwordSlot" && draggableItem.isSword){
            draggableItem.parentAfterDrag = transform;
            activeSword = draggableItem;
        }

        //throw new System.NotImplementedException();
        }
    }

    void Start(){
        varsObj = GameObject.Find("ThisIsToGetVariables");
        player = GameObject.Find("OverworldMC");
    }

    void FixedUpdate(){
        GameObject swordPrefab;

        if(GameObject.Find("SwordSlot").transform.childCount > 0){
            for(int i = 1; i < varsObj.GetComponent<DontDestroyScript>().itemPrefabs.Count + 1; i ++){
                if(GameObject.Find("SwordSlot").transform.childCount > 0){
                    if(varsObj.GetComponent<DontDestroyScript>().itemPrefabs[i-1].name == activeSword.name){
                        swordPrefab = varsObj.GetComponent<DontDestroyScript>().itemPrefabs[i-1];
                        player.GetComponent<PlayerScript>().selectedSword = swordPrefab;
                        strength.text = swordPrefab.GetComponent<Weapon>().damage.ToString();
                        player.GetComponent<PlayerScript>().playerDmg = swordPrefab.GetComponent<Weapon>().damage;
                    }
                }
            }
        }
        else{
            strength.text = "0";
            player.GetComponent<PlayerScript>().playerDmg = 0;
        }
    }
}
