using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNRealNoControls : MonoBehaviour
{
    private int clickCount;
    private const string specificSceneName1 = "final_ganaste_scene"; // First ending scene
    private const string specificSceneName2 = "final_perdiste_scene"; // Second ending scene
    private const string ClickCountKey = "ClickCount";
    private const string InitializedKey = "IsClickCountInitialized";

    private HashSet<int> loadedScenes = new HashSet<int>(); // Store loaded scene indices

    public void Start()
    {
        // Only reset clickCount to 0 if it hasn't been initialized yet
        if (!PlayerPrefs.HasKey(InitializedKey))
        {
            clickCount = 0;
            PlayerPrefs.SetInt(ClickCountKey, clickCount);
            PlayerPrefs.SetInt(InitializedKey, 1); // Set the initialization flag
        }
        else
        {
            // Load the previously saved click count
            clickCount = PlayerPrefs.GetInt(ClickCountKey, 0);
        }
    }

    public void PlayGame()
    {
        // Increment the click count and save it
        clickCount++;
        PlayerPrefs.SetInt(ClickCountKey, clickCount);

        if (clickCount > 5)
        {
            // Reset clickCount when loading the specific scene
            clickCount = 0;
            PlayerPrefs.SetInt(ClickCountKey, clickCount);

            // Clear the loaded scenes when loading the specific scene
            loadedScenes.Clear();

            // Randomly pick between the two specific scenes
            string selectedScene = Random.value > 0.5f ? specificSceneName1 : specificSceneName2;
            SceneManager.LoadScene(selectedScene);
            Debug.Log("Loading specific scene: " + selectedScene + " and resetting clickCount to 0");
        }
        else
        {
            int randomSceneIndex;

            // Generate a unique random scene index that hasn't been loaded yet
            do
            {
                randomSceneIndex = Random.Range(2, 11);
            } while (loadedScenes.Contains(randomSceneIndex));

            // Load the scene and add it to the list of loaded scenes
            loadedScenes.Add(randomSceneIndex);
            SceneManager.LoadScene(randomSceneIndex);
            Debug.Log("Loading random scene index: " + randomSceneIndex);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
