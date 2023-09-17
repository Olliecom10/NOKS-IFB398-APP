using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotManager : MonoBehaviour
{
    public Button screenshotButton;

    private void Start()
    {
        screenshotButton.onClick.AddListener(TakeScreenshot);
    }

    private void TakeScreenshot()
    {
        StartCoroutine(CaptureScreen());
    }

    private IEnumerator CaptureScreen()
    {
        // Wait for the end of the frame to ensure all rendering is complete
        yield return new WaitForEndOfFrame();

        // Capture the screen
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Convert the texture to a byte array
        byte[] screenshotBytes = screenshotTexture.EncodeToPNG();

        // Check Android version
        if (Application.platform == RuntimePlatform.Android)
        {
            if (AndroidVersionIsSupported())
            {
                // Save the screenshot to the gallery
                string screenshotFileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                //NativeGallery.SaveImageToGallery(screenshotBytes, "MyScreenshots", screenshotFileName);
                // MUST DO THIS ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                Debug.Log("Screenshot saved: " + screenshotFileName);
            }
            else
            {
                // Handle unsupported Android version
                Debug.LogWarning("Saving to gallery is not supported on this Android version.");
            }
        }
        else
        {
            // Handle other platforms or testing in Unity Editor
            Debug.LogWarning("Saving to gallery is not supported on this platform.");
        }

        // Clean up
        Destroy(screenshotTexture);
    }

    private bool AndroidVersionIsSupported()
    {
        // Check Android version here, return true if supported, false otherwise
        // You can use the `SystemInfo.operatingSystem` property to get the Android version
        // Example: "Android OS 7.0"
        // You can parse the version number and decide if it's supported or not
        // Example: "7.0" or "8.0"
        return true; // Modify this based on your version check logic
    }
}
