using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject shopNPC;
    public GameObject player;
    float angle = 180;
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
            if (Input.GetKeyDown(KeyCode.B))
            {
                shopUI.SetActive(true);
            }
            else if (shopUI.activeInHierarchy && Input.GetKeyUp(KeyCode.B))
            {
                shopUI.SetActive(false);
            }
        }
    }
}
