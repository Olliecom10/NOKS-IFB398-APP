using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    private bool isFrozen = false;
    private Texture2D frozenFrame;

    public RawImage background;
    public AspectRatioFitter fit;
    public Button freezeButton; // Assign your freeze/unfreeze button in the Unity Editor

    private void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find the back camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;
        camAvailable = true;

        // Add an onClick listener to the freezeButton
        freezeButton.onClick.AddListener(ToggleFreeze);
    }

    private void Update()
    {
        if (!camAvailable || isFrozen) // Stop updating the camera feed if it's frozen
        {
            return;
        }

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    // Function to toggle the freeze state when the button is pressed
    public void ToggleFreeze()
    {
        isFrozen = !isFrozen;

        if (isFrozen)
        {
            // If frozen, capture the current frame
            CaptureFrame();
        }
        else
        {
            // If unfrozen, reset the texture to the camera feed
            background.texture = backCam;
        }
    }

    // Function to capture the current frame when the camera feed is frozen
    private void CaptureFrame()
    {
        if (isFrozen)
        {
            frozenFrame = new Texture2D(backCam.width, backCam.height);
            frozenFrame.SetPixels(backCam.GetPixels());
            frozenFrame.Apply();
            // Display the frozen frame on the UI (You may need to assign a RawImage for this purpose)
            background.texture = frozenFrame;
        }
    }
}