using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastTravelButtons : MonoBehaviour
{
    public GameObject FastTravel;
    public Vector2 Location;
    public GameObject Player;
    public GameObject btn1, btn2, btn3, btn4, btn5, btn6, btn7;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button1()
    {
        FastTravel = GameObject.FindWithTag("FastTravel1");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn1 = GameObject.Find("Button1");
        btn1.GetComponent<Image>().color = Color.black;
    }
    public void Button2()
    {
        FastTravel = GameObject.FindWithTag("FastTravel2");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn2 = GameObject.Find("Button2");
        btn2.GetComponent<Image>().color = Color.black;
    }
    public void Button3()
    {
        FastTravel = GameObject.FindWithTag("FastTravel3");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn3 = GameObject.Find("Button3");
        btn3.GetComponent<Image>().color = Color.black;
    }
    public void Button4()
    {
        FastTravel = GameObject.FindWithTag("FastTravel4");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn6 = GameObject.Find("Button6");
        btn6.GetComponent<Image>().color = Color.black;
    }
    public void Button5()
    {
        FastTravel = GameObject.FindWithTag("FastTravel5");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn5 = GameObject.Find("Button5");
        btn5.GetComponent<Image>().color = Color.black;
    }
    public void Button6()
    {
        FastTravel = GameObject.FindWithTag("FastTravel6");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn7 = GameObject.Find("Button7");
        btn7.GetComponent<Image>().color = Color.black;
    }
    public void Button7()
    {
        FastTravel = GameObject.FindWithTag("FastTravel7");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
        btn4 = GameObject.Find("Button4");
        btn4.GetComponent<Image>().color = Color.black;
    }
}
