using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestingPressDatabase : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnImageClick()
    {
        // Load the "Expand Image" scene
        SceneManager.LoadScene("Expand Image", LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Expand Image")
        {
            // The ExpandImageHandler script should be present in the "Expand Image" scene
            // Access it using FindObjectOfType in the "Expand Image" scene
            ExpandImageHandler expandImageHandler = FindObjectOfType<ExpandImageHandler>();

            if (expandImageHandler != null)
            {
                // Get the sprite of the clicked image
                Sprite clickedImageSprite = transform.Find("Image").GetComponent<Image>().sprite;

                if (clickedImageSprite != null)
                {
                    Debug.Log("Clicked Image Sprite: " + clickedImageSprite);

                    // Set the expanded image in the ExpandImageHandler script
                    expandImageHandler.SetExpandedImage(clickedImageSprite);
                }
                else
                {
                    Debug.LogError("Clicked Image Sprite is null");
                }
            }
        }
    }
}
