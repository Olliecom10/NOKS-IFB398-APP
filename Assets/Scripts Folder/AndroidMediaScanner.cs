using UnityEngine;

public class AndroidMediaScanner : MonoBehaviour
{
#if UNITY_ANDROID
    public static void ScanFile(string filePath)
    {
        AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment");
        AndroidJavaObject externalStorage = environment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory");
        AndroidJavaObject file = new AndroidJavaObject("java.io.File", filePath);

        using (AndroidJavaClass mediaScannerConnection = new AndroidJavaClass("android.media.MediaScannerConnection"))
        {
            mediaScannerConnection.CallStatic("scanFile", AndroidMainActivity.Instance.gameObject, new string[] { file.Call<string>("getAbsolutePath") }, null, null);
        }
    }
#endif
}