using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravelButtons : MonoBehaviour
{
    public GameObject FastTravel;
    public Vector2 Location;
    public GameObject Player;
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
    }
    public void Button2()
    {
        FastTravel = GameObject.FindWithTag("FastTravel2");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
    }
    public void Button3()
    {
        FastTravel = GameObject.FindWithTag("FastTravel3");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
    }
    public void Button4()
    {
        FastTravel = GameObject.FindWithTag("FastTravel4");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
    }
    public void Button5()
    {
        FastTravel = GameObject.FindWithTag("FastTravel5");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
    }
    public void Button6()
    {
        FastTravel = GameObject.FindWithTag("FastTravel6");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
    }
    public void Button7()
    {
        FastTravel = GameObject.FindWithTag("FastTravel7");
        Location = FastTravel.transform.position;
        Player.transform.position = Location;
    }
}
