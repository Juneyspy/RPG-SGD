using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class textfunctions : MonoBehaviour
{
    public GameObject Joey;
    public Animator falling;
    public GameObject IceSpice;
    public GameObject Finaltext;
    public GameObject buttonforreveal;
    public GameObject basetextholder;

    public TMP_Text textabuse;
    public TMP_Text textabuseplus;
    public TMP_Text names;

    public int textcount;
    public Coroutine textstart;

    public Coroutine sc;


    // Start is called before the first frame update
    void Start()
    {
        //In here I need to write code that gets the "name" / tag of the character you are interacting with
        //once the code gets the characters name it will change it on the screen.
        // in an if statement that looks and compares the characters name, will have a function that gets called which holds a switch case for all the speech.
        //the picture of the character changes when the name of the character is being collected.
        textcount++;
        textabuse.text = "Hi";
        textabuseplus.text = "Hi";
        names.text = "player";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            IceSpice.SetActive(false);
        }
    }

    public void joeysux()
    {
        falling.SetBool("guyrises", true);
        textabuse.text = "do you know what antifa stands for?";
        textabuseplus.text = "do you know what antifa stands for?";
    }

    public void textwithJoe()
    {
        switch (textcount)
        {
            default:
                basetextholder.SetActive(true);
                Finaltext.SetActive(false);
                textabuse.text = "no worky :(";
                textabuseplus.text = "no worky :(";
                textcount++;
                buttonforreveal.SetActive(true);
                break;
            case 1:
                basetextholder.SetActive(true);
                Finaltext.SetActive(false);
                names.text = "joe bi";
                //textstart = StartCoroutine(textabuse.GetComponent<revealtext>().RevealText());
                //textabuse.GetComponent<revealtext>().startedCoroutine = textstart;
                textabuse.text = "shut up shut up shut up nigga, אני אוהב גלידה or whatever... BIDEN BLAST!!!!";
                textabuseplus.text = "shut up shut up shut up nigga, אני אוהב גלידה or whatever... BIDEN BLAST!!!!";
                sc = StartCoroutine(textabuse.GetComponent<revealtext>().RevealText());
                textabuse.GetComponent<revealtext>().startedCoroutine = sc;
                textcount++;
                buttonforreveal.SetActive(true);
                break;
            case 2:
                basetextholder.SetActive(true);
                Finaltext.SetActive(false);
                names.text = "player";
                textabuse.text = "Huh?";
                textabuseplus.text = "Huh?";
                sc = StartCoroutine(textabuse.GetComponent<revealtext>().RevealText());
                textabuse.GetComponent<revealtext>().startedCoroutine = sc;
                textcount++;
                buttonforreveal.SetActive(true);
                break;
            case 3:
                basetextholder.SetActive(true);
                Finaltext.SetActive(false);
                names.text = "joe bi";
                textabuse.text = "THIS ISNT EVEN 5 PERCENT OF MY FULL POWER!!!!!!";
                textabuseplus.text = "THIS ISNT EVEN 5 PERCENT OF MY FULL POWER!!!!!!";
                sc = StartCoroutine(textabuse.GetComponent<revealtext>().RevealText());
                textabuse.GetComponent<revealtext>().startedCoroutine = sc;
                //textcount = 0;
                buttonforreveal.SetActive(true);
                break;
        }
    }

    public void fulltextreveal()
    {
        basetextholder.SetActive(false);

        Finaltext.SetActive(true);
        buttonforreveal.SetActive(false);

        StopCoroutine(textabuse.GetComponent<revealtext>().startedCoroutine);
        //buttonforreveal.SetActive(true);
    }
}
