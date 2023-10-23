using UnityEngine;
using UnityEngine.UI;

public class CustomSlateFencing : MonoBehaviour
{
    public RawImage rawImage; // Reference to your Raw Image
    public Texture texture1;  // The texture to assign when setter = 1

    public static int setter; // Your variable to control texture assignment

    public void CustomSlate()
    {
        setter = 2;
    }
    public void CustomSlateRemove()
    {
        setter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (setter == 2)
        {
            rawImage.texture = texture1; // Assign texture1 to the Raw Image
        }
        // Add more conditions for other values of 'setter' if needed.
    }
}