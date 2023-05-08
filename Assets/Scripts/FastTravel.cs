using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastTravel : MonoBehaviour
{
    public GameObject Map, Minimap;
    public int press = 0;
    public GameObject btn1, btn2, btn3, btn4, btn5, btn6, btn7;
    // Start is called before the first frame update
    void Start()
    {
        Map.SetActive(false);
        Minimap.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        btn1 = GameObject.Find("Button1");
        btn2 = GameObject.Find("Button2");
        btn3 = GameObject.Find("Button3");
        btn4 = GameObject.Find("Button4");
        btn5 = GameObject.Find("Button5");
        btn6 = GameObject.Find("Button6");
        btn7 = GameObject.Find("Button7");
        if (Input.GetKeyDown(KeyCode.M) && press == 0)
        {
            Map.SetActive(true);
            Minimap.SetActive(false);
            press = 1;
            btn1.GetComponent<Image>().color = Color.white;
            btn2.GetComponent<Image>().color = Color.white;
            btn3.GetComponent<Image>().color = Color.white;
            btn4.GetComponent<Image>().color = Color.white;
            btn5.GetComponent<Image>().color = Color.white;
            btn6.GetComponent<Image>().color = Color.white;
            btn7.GetComponent<Image>().color = Color.white;
        }
        else if (Map.activeInHierarchy && Input.GetKeyDown(KeyCode.M) && press == 1)
        {
            Map.SetActive(false);
            Minimap.SetActive(true);
            press = 0;
            btn1.GetComponent<Image>().color = Color.white;
            btn2.GetComponent<Image>().color = Color.white;
            btn3.GetComponent<Image>().color = Color.white;
            btn4.GetComponent<Image>().color = Color.white;
            btn5.GetComponent<Image>().color = Color.white;
            btn6.GetComponent<Image>().color = Color.white;
            btn7.GetComponent<Image>().color = Color.white;
        }
    }
}
