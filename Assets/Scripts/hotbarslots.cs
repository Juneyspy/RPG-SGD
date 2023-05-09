using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class hotbarslots : MonoBehaviour, IDropHandler
{
    public GameObject varsObj;

    public DraggableItem activeSword;
    public DraggableItem activeArmor;

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
        else if(gameObject.name == "ArmorSlot" && draggableItem.isArmor){
            draggableItem.parentAfterDrag = transform;
            activeArmor = draggableItem;
        }

        //throw new System.NotImplementedException();
        }
    }

    void Start(){
        varsObj = GameObject.Find("ThisIsToGetVariables");
    }

    void FixedUpdate(){
        string swordName;
        string armorName;
        GameObject swordPrefab;
        GameObject armorPrefab;

        //if(varsObj.GetComponent<DontDestroyScript>().itemPrefabs.Contains())
        
        /*for(i = 1; i < varsObj.GetComponent<DontDestroyScript>().itemPrefabs.Count + 1; i ++){
            if(varsObj.GetComponent<DontDestroyScript>().itemPrefabs)
        }*/ //FIX THIS

        GameObject.Find("str (1)").GetComponent<TextMeshPro>().text = activeSword.GetComponent<Weapon>().damage.ToString();
        GameObject.Find("def (1)").GetComponent<TextMeshPro>().text = activeArmor.GetComponent<Armor>().armor.ToString();
    }
}
