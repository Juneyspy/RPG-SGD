using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    GameObject inv;
    GameObject trash;
    GameObject player;
    public bool isSword;
    public bool isArmor;
    public int damage;
    public int armor;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin drag");

        parentAfterDrag = transform.parent;

        transform.SetParent(transform.root.GetChild(0));

        transform.SetAsLastSibling();

        image.raycastTarget = false;

        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("dragging");

        transform.position = Input.mousePosition;

        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end drag");



        transform.SetParent(parentAfterDrag);

        image.raycastTarget = true;

        //throw new System.NotImplementedException();
    }

    void Start(){
        inv = GameObject.Find("quick slots");
        trash = inv.transform.GetChild(35).gameObject;
        player = GameObject.Find("OverworldMC");

        if(gameObject.name.Contains("Sword")){
            isSword = true;
        }
        else if(gameObject.name.Contains("Armor")){
            isArmor = true;
        }
        else{
            isArmor = false;
            isSword = false;
        }
    }

    void Update(){
        if(/*GameObject.Find("OverworldMC").GetComponent<PlayerScript>().invOpened && */GameObject.Find("OverworldMC").GetComponent<PlayerScript>().inventoryScreen.activeSelf){//&& player.GetComponent<PlayerScript>().inventoryScreen.activeSelf
            if (trash.transform.childCount > 0){
                Destroy(trash.transform.GetChild(0).gameObject);
            }
        }
    }

}
