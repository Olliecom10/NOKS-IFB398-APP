using UnityEngine;
using UnityEngine.UI;

public class CustomSlateFencing : MonoBehaviour
{
    public RawImage rawImage; // Reference to the RawImage component
    public Texture selectedTexture; // New field to select the texture within this script

    // Start is called before the first frame update
    void Start()
    {
        if (rawImage != null)
        {
            if (selectedTexture != null)
            {
                rawImage.texture = selectedTexture;
            }
            else
            {
                Debug.LogError("No texture selected in the ImageDisplay script.");
            }
        }
        else
        {
            Debug.LogError("RawImage not assigned in the Unity Editor.");
        }
    }

    // Function to set the selected texture from outside this script
    public void SetSelectedTexture(Texture texture)
    {
        selectedTexture = texture;
    }
}