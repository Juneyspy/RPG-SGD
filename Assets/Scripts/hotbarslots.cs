using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hotbarslots : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
        GameObject dropped = eventData.pointerDrag;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        
        if(gameObject.name == "SwordSlot" && draggableItem.isSword){
            draggableItem.parentAfterDrag = transform;
        }
        else if(gameObject.name == "ArmorSlot" && draggableItem.isArmor){
            draggableItem.parentAfterDrag = transform;
        }

        //throw new System.NotImplementedException();
        }
    }
}
