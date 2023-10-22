using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandImageHandler : MonoBehaviour
{
    public Image expandedImage;

    // Method to set the expanded image
    public void SetExpandedImage(Sprite sprite)
    {
        expandedImage.sprite = sprite;


    }


}