using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public int foxycount;
    public GameObject foxyhold;
    public GameObject runes;
    public GameObject inventory;
    public GameObject travel;
    public GameObject journal;
    public GameObject buttongone1;
    public GameObject buttongone2;
    public Animator buttonfade;
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

    public void runescreen()
    {
        runes.SetActive(true);
        inventory.SetActive(false);
        travel.SetActive(false);
        journal.SetActive(false);
    }
    public void inventoryscreen()
    {
        runes.SetActive(false);
        inventory.SetActive(true);
        travel.SetActive(false);
        journal.SetActive(false);
    }
    public void travelscreen()
    {
        runes.SetActive(false);
        inventory.SetActive(false);
        travel.SetActive(true);
        journal.SetActive(false);
    }
    public void journalscreen()
    {
        runes.SetActive(false);
        inventory.SetActive(false);
        travel.SetActive(false);
        journal.SetActive(true);
    }

    public void pleasejustplease()
    {
        buttongone1.SetActive(false);
        buttongone2.SetActive(false);
    }
}
