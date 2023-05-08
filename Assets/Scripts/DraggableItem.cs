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
    }

    void Update(){
        if(player.GetComponent<PlayerScript>().invOpened && player.GetComponent<PlayerScript>().inventoryScreen.activeSelf){
            if (trash.transform.childCount > 0){
                Destroy(trash.transform.GetChild(0).gameObject);
            }
        }
    }

}
