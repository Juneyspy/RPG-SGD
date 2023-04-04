using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    private float timeToWait = 0.1f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Hovered");
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        //Debug.Log("exited");
        StopAllCoroutines();
        ImageHoverTool.OnMouseLoseFocus();
    }

    private void ShowMessage()
    {
        ImageHoverTool.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);

        ShowMessage();
    }
}
