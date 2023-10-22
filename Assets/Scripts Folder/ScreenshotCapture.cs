using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotCapture : MonoBehaviour
{
    public Button screenshotButton;

    private void Start()
    {
        screenshotButton.onClick.AddListener(TakeScreenshot);
    }

    void TakeScreenshot()
    {
        string screenshotFilename = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        string screenshotPath = Path.Combine(Application.persistentDataPath, screenshotFilename);

        ScreenCapture.CaptureScreenshot(screenshotPath);
    }
}