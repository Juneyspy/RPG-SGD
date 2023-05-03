using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class RuneSmithFunctions : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject confirmscreen;
    public int changecount;
    public GameObject RuneInventory;
    public GameObject totalInv;
    public GameObject Inv;
    public GameObject holdingWeapon;
    public GameObject oneruneset;
    public GameObject tworuneset;
    public GameObject threeruneset;
    public GameObject fourruneset;
    public int check;
    string nameholder;
    string nameholder2;
    private GameObject thatguy;
    private GameObject thatguy2;
    public GameObject FullScreen;
    public GameObject picture1;
    public GameObject picture2;
    public GameObject picture3;
    public GameObject picture4;



    // Start is called before the first frame update
    void Start()
    {
        picture1.SetActive(false);
        picture2.SetActive(false);
        picture3.SetActive(false);
        picture4.SetActive(false);

        oneruneset.SetActive(false);
        tworuneset.SetActive(false);
        threeruneset.SetActive(false);
        fourruneset.SetActive(false);
        //if in inventory slot 1 or something:
        // if rune slot amount set the corresponging one active.

        GetFirstWeapon();
    }

    public void GetFirstWeapon()
    {

        Inv.SetActive(true);
        totalInv.SetActive(true);
        for (int i = 1; i < 2; i++)
        {
            if (totalInv.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
            {
                holdingWeapon = totalInv.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject;
            }
        }
        //holdingWeapon.tag = "1 rune";
        totalInv.SetActive(false);
        Inv.SetActive(false);
        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "1 rune")
        {
            check = 2;
            oneruneset.SetActive(true);
            tworuneset.SetActive(false);
            threeruneset.SetActive(false);
            fourruneset.SetActive(false);
            RuneInventory = oneruneset;


            picture1.SetActive(true);
            picture2.SetActive(false);
            picture3.SetActive(false);
            picture4.SetActive(false);
        }

        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "2 rune")
        {
            check = 3;
            tworuneset.SetActive(true);
            oneruneset.SetActive(false);
            threeruneset.SetActive(false);
            fourruneset.SetActive(false);
            RuneInventory = tworuneset;


            picture1.SetActive(true);
            picture2.SetActive(true);
            picture3.SetActive(false);
            picture4.SetActive(false);
        }

        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "3 rune")
        {
            check = 4;
            threeruneset.SetActive(true);
            tworuneset.SetActive(false);
            oneruneset.SetActive(false);
            fourruneset.SetActive(false);
            RuneInventory = threeruneset;


            picture1.SetActive(true);
            picture2.SetActive(true);
            picture3.SetActive(true);
            picture4.SetActive(false);
        }

        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "4 rune")
        {
            check = 5;
            fourruneset.SetActive(true);
            tworuneset.SetActive(false);
            threeruneset.SetActive(false);
            oneruneset.SetActive(false);
            RuneInventory = fourruneset;


            picture1.SetActive(true);
            picture2.SetActive(true);
            picture3.SetActive(true);
            picture4.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (FullScreen.activeSelf)
        {
            int runs = 1;

            for (int i = 1; i < check; i++)
            {
                if (RuneInventory.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                {

                    //this shit here needs to be able to change the image on the sword to what ever is currently in the slots but no worky :(


                    nameholder2 = RuneInventory.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                    thatguy = GameObject.Find(nameholder2);

                    if (runs == 1)
                    {
                        runs++;
                        Image sourceholder = thatguy.GetComponent<Image>();
                        Image setholder = picture1.GetComponent<Image>();

                        setholder.sprite = sourceholder.sprite;

                    }

                    if (runs == 2)
                    {
                        runs++;
                        Image sourceholder2 = thatguy.GetComponent<Image>();
                        Image setholder2 = picture2.GetComponent<Image>();

                        setholder2.sprite = sourceholder2.sprite;
                    }

                    if (runs == 3)
                    {
                        runs++;
                        Image sourceholder3 = thatguy.GetComponent<Image>();
                        Image setholder3 = picture3.GetComponent<Image>();

                        setholder3.sprite = sourceholder3.sprite;
                    }

                    if (runs == 4)
                    {

                        Image sourceholder4 = thatguy.GetComponent<Image>();
                        Image setholder4 = picture4.GetComponent<Image>();

                        setholder4.sprite = sourceholder4.sprite;
                    }

                }
            }
        }

    }

    public void ClearRunes()
    {

        confirmscreen.SetActive(false);

        for (int i = 1; i < check; i++)
        {
            if (RuneInventory.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
            {
                nameholder = RuneInventory.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                thatguy = GameObject.Find(nameholder);
                Destroy(thatguy);
            }
        }

    }

    public void DoubleCheck()
    {
        confirmscreen.SetActive(true);
    }

    public void BacktoRunescreen()
    {
        confirmscreen.SetActive(false);
    }

    public void changeweapon()
    {
        if (changecount % 2 == 0)
        {
            changecount++;
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
        }
        else
        {
            changecount++;
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
        }

    }
}
