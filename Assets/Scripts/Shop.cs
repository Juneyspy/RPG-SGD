using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject shopNPC;
    public GameObject player;
    float angle = 88;
    public int press = 0;

    public int MoneySpent;
    public TMP_Text nameofitem;
    public GameObject Quantity;
    public int gold;
    public int TotalCost = 150;
    public TMP_InputField quantityvalue;
    public int multiplycost;
    public TMP_Text quantitycost;
    // Start is called before the first frame update
    void Start()
    {
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Angle(player.transform.forward, transform.position - player.transform.position) < angle)
        {
            if (Input.GetKeyDown(KeyCode.B) && press == 0)
            {
                shopUI.SetActive(true);
                press = 1;
            }
            else if (shopUI.activeInHierarchy && Input.GetKeyDown(KeyCode.B) && press == 1)
            {
                shopUI.SetActive(false);
                press = 0;
            }
        }
    }

    public void QuantityScreen()
    {
        Quantity.SetActive(true);
        nameofitem.text = "potion";
        //quantitycost.text = (quantityvalue.value * TotalCost).text;
    }

    public void PotionCost()
    {
        gold--;//put in the amount of whatever the item costs here
    }
}
