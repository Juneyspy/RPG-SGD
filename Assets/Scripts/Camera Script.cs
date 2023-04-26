using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    public bool following = true;
    public Vector3 battleLoc = new Vector3(650,700, -12.11325f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OverworldMC");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(following){
            gameObject.transform.position = player.gameObject.transform.position + new Vector3(0,0,-12.11325f);
        }
    }
}
