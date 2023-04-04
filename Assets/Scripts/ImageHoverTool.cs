using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ImageHoverTool : MonoBehaviour
{
    public TextMeshProUGUI tiptext;
    public RectTransform tipWindow;
    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;


    private void OnEnable()
    {
        OnMouseHover += Showtip;
        OnMouseLoseFocus += HideTip;
    }

    private void OnDisable()
    {
        OnMouseHover -= Showtip;
        OnMouseLoseFocus -= HideTip;
    }

    void Start()
    {
        HideTip();
    }

    private void Showtip(string tip, Vector2 mousepos)
    {
        tiptext.text = tip;
        tipWindow.sizeDelta = new Vector2(tiptext.preferredWidth > 200 ? 200 : tiptext.preferredWidth, tiptext.preferredHeight);

        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(mousepos.x + tipWindow.sizeDelta.x * .7f, mousepos.y);
    }
    private void HideTip()
    {
        tiptext.text = default;
        tipWindow.gameObject.SetActive(false);
    }
}
