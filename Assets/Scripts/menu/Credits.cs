using UnityEngine;
using UnityEngine.UI;

public class CanvasToggle : MonoBehaviour
{
    public Canvas canvasToToggle; // Reference to the Canvas you want to toggle

    void Start()
    {
        // Make sure the Canvas is initially deactivated
        
    }

    public void ToggleCanvas()
    {
        canvasToToggle.gameObject.SetActive(!canvasToToggle.gameObject.activeSelf);
    }
}