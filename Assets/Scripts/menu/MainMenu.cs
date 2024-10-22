using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("click");

    }
    public void Update()
    {
      //  Debug.Log("click");
       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("click");
    }
    /*
       public void gotToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void gotToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    */


    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("click");
        Application.Quit();
    }
}
