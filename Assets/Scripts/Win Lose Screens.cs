using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreens : MonoBehaviour
{
    public GameObject Winscreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("FrontEnd");
        Winscreen.SetActive(false);
        loseScreen.SetActive(false);

    }
}
