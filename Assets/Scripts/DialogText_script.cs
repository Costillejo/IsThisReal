using System;
using System.Collections;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class DialogTextAnimator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float delay = 0.1f;
    public string window = "";




    private string DialogText = "";
    private string window_1 =
               "Buenos dias señorita.\n"
               + "Voy a hacerle unas preguntas.\n"
               + "Usted digame\n"
               + "si lo que ve es real o no. \n";

    private string window_2 =
              "Bien..Me alegra que estes consciente.\n"
              + "Sigamos con la siguiente imagen..\n"
              + "Usted digame\n"
              + "si lo que ve es real o no. \n";

   
    private float clearDelay = 2f; // Delay before clearing text


    private bool showCursor = true;

    void Start()
    {
        StartCoroutine(TypeText());
       // StartCoroutine(BlinkCursor());
    }

    IEnumerator TypeText()
    {
        DialogText = "";
        switch (window)
        {
            case "window_1":
                DialogText = window_1;
                Debug.Log(window_1);
                break;

            case "window_2":
                DialogText = window_2;
                Debug.Log(window_2);
                break;

            default:
                Debug.Log("No valid window selected");
                break;
        }
        /*
        else
        {
            yield return new WaitForSeconds(2); // Delay for 2 seconds
        }
        */

        textMeshPro.text = "";
       
        foreach (char letter in DialogText.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(delay);
        }
      //  textMeshPro.text += "_"; // initial cursor
      /*
        if (!title) {
            ClearText();
            StartCoroutine(BlinkCursor()); 
            yield return new WaitForSeconds(clearDelay);
            DialogText = DialogTextSubtitle2;
            foreach (char letter in DialogText.ToCharArray())
            {
                textMeshPro.text += letter;
                yield return new WaitForSeconds(delay);
            }
              // textMeshPro.text += "_"; // initial cursor
        } // Delay for 2 seconds
        if (!title) {
            yield return new WaitForSeconds(2); // Delay for 2 seconds
            StartCoroutine(TypeText());
        }
      */
       
    }


    void ClearText()
    {
        textMeshPro.text = ""; // Clear all text at once
    }

    IEnumerator BlinkCursor()
    {
        float blinkDuration = 1.5f; // Total duration for blinking effect
        float timer = 0f;
        float cursorBlinkRate = 0.5f;
        while (timer < blinkDuration)
        {
            textMeshPro.text = "_"; // Show the cursor
            yield return new WaitForSeconds(cursorBlinkRate);
            textMeshPro.text = ""; // Hide the cursor
            yield return new WaitForSeconds(cursorBlinkRate);
            timer += cursorBlinkRate * 2; // Each blink cycle takes cursorBlinkRate seconds
        }
    }
}