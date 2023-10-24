using UnityEngine;

public class AndroidMainActivity : MonoBehaviour
{
    public static AndroidMainActivity _instance;

    public static AndroidMainActivity Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("AndroidMainActivity").AddComponent<AndroidMainActivity>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    // This method is called when the application starts.
    void Start()
    {
        // Initialize the AndroidMainActivity instance.
        _instance = this;
    }
}