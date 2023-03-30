using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public int foxycount;
    public GameObject foxyhold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickcounter()
    {
        foxycount++;
        if (foxycount == 10)
        {
            foxyhold.SetActive(true);
            Invoke("foxygone", 0.35f);
        }
    }

    public void foxygone()
    {
        foxyhold.SetActive(false);
    }
}
