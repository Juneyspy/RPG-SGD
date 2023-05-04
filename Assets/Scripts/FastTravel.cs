using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravel : MonoBehaviour
{
    public GameObject Map, Minimap;
    public int press = 0;
    // Start is called before the first frame update
    void Start()
    {
        Map.SetActive(false);
        Minimap.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && press == 0)
        {
            Map.SetActive(true);
            Minimap.SetActive(false);
            press = 1;
        }
        else if (Map.activeInHierarchy && Input.GetKeyDown(KeyCode.M) && press == 1)
        {
            Map.SetActive(false);
            Minimap.SetActive(true);
            press = 0;
        }
    }
}
