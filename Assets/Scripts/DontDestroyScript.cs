using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public List<GameObject> itemPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(gameObject.name == "inventory holder" || gameObject.name == "RuneSmith Screen" /*|| gameObject.name == "Pause GUI"*/){
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
