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
    public GameObject RuneInventory2;
    public GameObject totalInv;
    public GameObject Inv;
    public GameObject holdingWeapon;

    public GameObject oneruneset;
    public GameObject tworuneset;
    public GameObject threeruneset;
    public GameObject fourruneset;
    public GameObject onerunesetarmor;
    public GameObject tworunesetarmor;
    public GameObject threerunesetarmor;
    public GameObject fourrunesetarmor;

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
    public GameObject picture5;
    public GameObject picture6;
    public GameObject picture7;
    public GameObject picture8;

    public Image setholder;
    public Image setholder2;
    public Image setholder3;
    public Image setholder4;
    public Image setholder5;
    public Image setholder6;
    public Image setholder7;
    public Image setholder8;

    public Sprite blank;

    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;
    public GameObject block6;
    public GameObject block7;




    // Start is called before the first frame update
    void Start()
    {
        block1.SetActive(false);
        block2.SetActive(false);
        block3.SetActive(false);
        block4.SetActive(false);
        block5.SetActive(false);
        block6.SetActive(false);
        block7.SetActive(false);

        picture1.SetActive(false);
        picture2.SetActive(false);
        picture3.SetActive(false);
        picture4.SetActive(false);
        picture5.SetActive(false);
        picture6.SetActive(false);
        picture7.SetActive(false);
        picture8.SetActive(false);

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
        if (Weapon1.activeSelf)
        {
            for (int i = 1; i < 2; i++)
            {
                if (totalInv.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                {
                    holdingWeapon = totalInv.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject;
                }
            }
        }
        if (Weapon2.activeSelf)
        {
            for (int i = 1; i < 3; i++)
            {
                if (totalInv.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                {
                    holdingWeapon = totalInv.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject;
                }
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

        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "1 rune armor")
        {
            check = 2;
            onerunesetarmor.SetActive(true);
            tworunesetarmor.SetActive(false);
            threerunesetarmor.SetActive(false);
            fourrunesetarmor.SetActive(false);
            RuneInventory2 = onerunesetarmor;

            picture5.SetActive(true);
            picture6.SetActive(false);
            picture7.SetActive(false);
            picture8.SetActive(false);
        }
        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "2 rune armor")
        {
            check = 3;
            onerunesetarmor.SetActive(false);
            tworunesetarmor.SetActive(true);
            threerunesetarmor.SetActive(false);
            fourrunesetarmor.SetActive(false);
            RuneInventory2 = tworunesetarmor;

            picture5.SetActive(true);
            picture6.SetActive(true);
            picture7.SetActive(false);
            picture8.SetActive(false);

        }
        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "3 rune armor")
        {
            check = 4;
            onerunesetarmor.SetActive(false);
            tworunesetarmor.SetActive(false);
            threerunesetarmor.SetActive(true);
            fourrunesetarmor.SetActive(false);
            RuneInventory2 = threerunesetarmor;

            picture5.SetActive(true);
            picture6.SetActive(true);
            picture7.SetActive(true);
            picture8.SetActive(false);

        }
        if (holdingWeapon.tag != null && holdingWeapon.tag.ToString() == "4 rune armor")
        {
            check = 5;
            onerunesetarmor.SetActive(false);
            tworunesetarmor.SetActive(false);
            threerunesetarmor.SetActive(false);
            fourrunesetarmor.SetActive(true);
            RuneInventory2 = fourrunesetarmor;

            picture5.SetActive(true);
            picture6.SetActive(true);
            picture7.SetActive(true);
            picture8.SetActive(true);

        }
    }

    public void blockrunes()
    {
        block7.SetActive(true);
    }

    public void CloseScreen()
    {
        FullScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (FullScreen.activeSelf)
        {
            int runs = 1;
            if (Weapon1.activeSelf)
            {
                for (int i = 1; i < check; i++)
                {
                    if (RuneInventory.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                    {

                        nameholder2 = RuneInventory.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                        thatguy = GameObject.Find(nameholder2);

                        if (runs == 1)
                        {
                            picture1.GetComponent<Image>().enabled = true;

                            Image sourceholder = thatguy.GetComponent<Image>();
                            setholder = picture1.GetComponent<Image>();

                            setholder.sprite = sourceholder.sprite;

                            thatguy = null;

                        }

                        if (runs == 2)
                        {
                            picture2.GetComponent<Image>().enabled = true;

                            Image sourceholder2 = thatguy.GetComponent<Image>();
                            setholder2 = picture2.GetComponent<Image>();

                            setholder2.sprite = sourceholder2.sprite;

                            thatguy = null;
                        }

                        if (runs == 3)
                        {
                            picture3.GetComponent<Image>().enabled = true;

                            Image sourceholder3 = thatguy.GetComponent<Image>();
                            setholder3 = picture3.GetComponent<Image>();

                            setholder3.sprite = sourceholder3.sprite;

                            thatguy = null;
                        }

                        if (runs == 4)
                        {
                            picture4.GetComponent<Image>().enabled = true;

                            Image sourceholder4 = thatguy.GetComponent<Image>();
                            setholder4 = picture4.GetComponent<Image>();

                            setholder4.sprite = sourceholder4.sprite;

                            thatguy = null;
                        }
                        runs++;

                    }

                }

            }

            if (Weapon2.activeSelf)
            {
                for (int i = 1; i < check; i++)
                {
                    if (RuneInventory2.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                    {
                        nameholder2 = RuneInventory2.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                        thatguy = GameObject.Find(nameholder2);

                        if (runs == 1)
                        {

                            picture5.GetComponent<Image>().enabled = true;

                            Image sourceholder5 = thatguy.GetComponent<Image>();
                            setholder5 = picture5.GetComponent<Image>();

                            setholder5.sprite = sourceholder5.sprite;

                            thatguy = null;

                        }

                        if (runs == 2)
                        {
                            picture6.GetComponent<Image>().enabled = true;

                            Image sourceholder6 = thatguy.GetComponent<Image>();
                            setholder6 = picture6.GetComponent<Image>();

                            setholder6.sprite = sourceholder6.sprite;

                            thatguy = null;
                        }

                        if (runs == 3)
                        {
                            picture7.GetComponent<Image>().enabled = true;

                            Image sourceholder7 = thatguy.GetComponent<Image>();
                            setholder7 = picture7.GetComponent<Image>();

                            setholder7.sprite = sourceholder7.sprite;

                            thatguy = null;
                        }

                        if (runs == 4)
                        {
                            picture8.GetComponent<Image>().enabled = true;

                            Image sourceholder8 = thatguy.GetComponent<Image>();
                            setholder8 = picture8.GetComponent<Image>();

                            setholder8.sprite = sourceholder8.sprite;

                            thatguy = null;
                        }
                        runs++;

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
            if (i == 1)
            {
                //picture1.GetComponent<Image>().sprite = blank;
                //setholder = picture1.GetComponent<Image>();
                //setholder.sprite = null;

                picture1.GetComponent<Image>().enabled = false;
                picture5.GetComponent<Image>().enabled = false;

            }
            else if(i == 2)
            {
                //setholder2 = picture2.GetComponent<Image>();
                //setholder2.sprite = blank;

                picture2.GetComponent<Image>().enabled = false;
                picture6.GetComponent<Image>().enabled = false;

            }
            else if(i == 3)
            {
                //setholder3 = picture3.GetComponent<Image>();
                //setholder3.sprite = blank;
                //print(setholder3.sprite);

                picture3.GetComponent<Image>().enabled = false;
                picture7.GetComponent<Image>().enabled = false;
            }
            else if(i == 4)
            {
                //setholder4 = picture4.GetComponent<Image>();
                //setholder4.sprite = null;

                picture4.GetComponent<Image>().enabled = false;
                picture8.GetComponent<Image>().enabled = false;

            }
            if (Weapon1.activeSelf)
            {
                if (RuneInventory.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                {
                    nameholder = RuneInventory.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                    thatguy = GameObject.Find(nameholder);
                    Destroy(thatguy);
                }
            }
            if (Weapon2.activeSelf)
            {
                if (RuneInventory2.transform.GetChild(i - 1).gameObject.transform.childCount > 0)
                {
                    nameholder = RuneInventory2.transform.GetChild(i - 1).gameObject.transform.GetChild(0).gameObject.name.ToString();
                    thatguy = GameObject.Find(nameholder);
                    Destroy(thatguy);
                }
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
            GetFirstWeapon();
        }
        else
        {
            changecount++;
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            GetFirstWeapon();
        }

    }
}
