using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class revealtext : MonoBehaviour
{
    public bool clicked = false;
    public TMP_Text text;
    public Coroutine startedCoroutine;

    void Start()
    {
        startedCoroutine = StartCoroutine(RevealText());
    }

    public IEnumerator RevealText()
    {
        var originalString = text.text;
        text.text = "";

        var numCharsRevealed = 0;
        while (numCharsRevealed < originalString.Length && !clicked)
        {
            while (originalString[numCharsRevealed] == ' ')
                ++numCharsRevealed;

            ++numCharsRevealed;

            text.text = originalString.Substring(0, numCharsRevealed);

            yield return new WaitForSeconds(0.055f); 
        }
    }
}
