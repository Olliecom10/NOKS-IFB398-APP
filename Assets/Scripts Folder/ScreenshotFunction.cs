using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenshotFunction : MonoBehaviour
{
    public string screenshotPath = "/Screenshots/"; // Define the path to store screenshots.

    private void Awake()
    {
        // Create the screenshot directory if it doesn't exist.
        Directory.CreateDirectory(Application.persistentDataPath + screenshotPath);
    }

    public void CaptureScreenshot()
    {
        // Generate a unique filename for the screenshot.
        string filename = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        string screenshotFilePath = Application.persistentDataPath + screenshotPath + filename;

        // Capture the screenshot and save it.
        ScreenCapture.CaptureScreenshot(screenshotFilePath);
        StartCoroutine(WaitForScreenshot(screenshotFilePath));
    }

    IEnumerator WaitForScreenshot(string screenshotFilePath)
    {
        yield return new WaitForEndOfFrame();

        // Check if the screenshot was saved.
        if (File.Exists(screenshotFilePath))
        {
            // You can also display a confirmation message to the user here.
            Debug.Log("Screenshot saved: " + screenshotFilePath);

            // To make the screenshot accessible in the device's photos gallery, use Android's MediaScanner.
            AndroidMediaScanner.ScanFile(screenshotFilePath);
        }
        else
        {
            Debug.LogError("Screenshot capture failed.");
        }
    }
}