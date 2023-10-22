using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingPressDatabase : MonoBehaviour
{
    public void OnImageClick()
    {
        // Load the "Expand Image" scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Expand Image");

        // Access the ExpandImageHandler script in the "Expand Image" scene
        ExpandImageHandler expandImageHandler = FindObjectOfType<ExpandImageHandler>();

        if (expandImageHandler != null)
        {
            // Get the sprite of the clicked image
            Sprite clickedImageSprite = transform.Find("Image").GetComponent<Image>().sprite;

            Debug.Log("Clicked Image Sprite: " + clickedImageSprite);

            // Set the expanded image in the ExpandImageHandler script
            expandImageHandler.SetExpandedImage(clickedImageSprite);
        }
    }
}
