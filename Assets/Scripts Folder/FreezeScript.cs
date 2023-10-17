using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class FreezeScript : MonoBehaviour
{
    public Camera arCamera; // Reference to your AR Camera.
    private bool isFrozen = false; // Flag to track if the camera feed is frozen.

    public void ToggleFreezeScreen()
    {
        if (arCamera != null)
        {
            // Toggle between "Solid Color" and "Nothing" to freeze/unfreeze the camera feed.
            arCamera.clearFlags = isFrozen ? CameraClearFlags.SolidColor : CameraClearFlags.Nothing;
            isFrozen = !isFrozen;
        }
    }
}