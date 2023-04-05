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

    public TMP_Text textabuse;
    public TMP_Text names;

    //If player presses space or something it turns the text box off thus "skipping" it.


    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
