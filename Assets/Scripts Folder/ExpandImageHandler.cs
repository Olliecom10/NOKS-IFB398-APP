using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandImageHandler : MonoBehaviour
{
    public Image expandedImage;

    public void SetExpandedImage(Sprite sprite)
    {
        Debug.Log("SetExpandedImage called");
        if (sprite != null)
        {
            expandedImage.sprite = sprite;
            Debug.Log("Expanded image set successfully");
        }
        else
        {
            Debug.LogError("Sprite is null");
        }
    }


}