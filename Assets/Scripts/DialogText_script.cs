using System;
using System.Collections;
using TMPro;
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


    private string window_3 =
             "Bien.. Me alegra \n" +
             "que estes consciente. \n" +
             "Sigamos con la siguiente \n" +
             "imagen..";


    private string window_4 =
               "No, eso definitivamente. \n"
             + "no es real por suerte. \n"
             + "Tomate una de las pastillas \n"
             + "por favor, y sigamos a la siguiente imagen \n";

    private string window_5 =
           "No, eso no es real.\n"
         + "Ademas, te estas agitando.\n"
         + "Tus manos estan transpiradas.. \n"
         + "Por favor, toma,otra pastilla, y sigamos con las imagenes \n";


    private string window_6 =
             "Bien.. Vamos Avanzando \n" +
             "Sigamos con la siguiente \n" +
             "imagen..";

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
                break;
            case "window_2":
                DialogText = window_2;            
                break;
            case "window_3":
                DialogText = window_3;              
                break;
            case "window_4":
                DialogText = window_4;              
                break;
            case "window_5":
                DialogText = window_5;             
                break;
            case "window_6":
                DialogText = window_6;
                break;
            default:
                Debug.Log("No valid window selected");
                break;
        }
       

        textMeshPro.text = "";
       
        foreach (char letter in DialogText.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(delay);
        }
     
       
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