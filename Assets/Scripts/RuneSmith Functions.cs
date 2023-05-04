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

    public Image setholder;
    public Image setholder2;
    public Image setholder3;
    public Image setholder4;
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
                        block1.SetActive(true);
                        if(fourruneset.activeSelf)
                        {
                            block5.SetActive(true);
                            block1.SetActive(false);
                        }
                        if (threeruneset)
                        {

                        }
                        if (tworuneset)
                        {
                            block2.SetActive(true);
                            block1.SetActive(false);
                        }

                        Image sourceholder = thatguy.GetComponent<Image>();
                        setholder = picture1.GetComponent<Image>();

                        setholder.sprite = sourceholder.sprite;

                        thatguy = null;

                    }

                    if (runs == 2)
                    {
                        block1.SetActive(true);
                        if (tworuneset.activeSelf)
                        {
                            //block2.SetActive(true);
                        }

                        Image sourceholder2 = thatguy.GetComponent<Image>();
                        setholder2 = picture2.GetComponent<Image>();

                        setholder2.sprite = sourceholder2.sprite;

                        thatguy = null;
                    }

                    if (runs == 3)
                    {
                        block3.SetActive(true);

                        if (threeruneset.activeSelf)
                        {
                            Debug.Log("cum");
                        }

                        Image sourceholder3 = thatguy.GetComponent<Image>();
                        setholder3 = picture3.GetComponent<Image>();

                        setholder3.sprite = sourceholder3.sprite;

                        thatguy = null;
                    }

                    if (runs == 4)
                    {
                        block3.SetActive(true);
                        block4.SetActive(true);
                        block7.SetActive(true);
                        block6.SetActive(true);

                        Image sourceholder4 = thatguy.GetComponent<Image>();
                        setholder4 = picture4.GetComponent<Image>();

                        setholder4.sprite = sourceholder4.sprite;

                        thatguy = null;
                    }
                    runs++;

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
            }
            else if(i == 2)
            {
                //setholder2 = picture2.GetComponent<Image>();
                //setholder2.sprite = blank;

                picture2.GetComponent<Image>().enabled = false;
            }
            else if(i == 3)
            {
                //setholder3 = picture3.GetComponent<Image>();
                //setholder3.sprite = blank;
                //print(setholder3.sprite);

                picture3.GetComponent<Image>().enabled = false;
            }
            else if(i == 4)
            {
                //setholder4 = picture4.GetComponent<Image>();
                //setholder4.sprite = null;

                picture4.GetComponent<Image>().enabled = false;
            }
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
