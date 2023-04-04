using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = player.gameObject.transform.position + new Vector3(0,0,-12.11325f);
    }
}
