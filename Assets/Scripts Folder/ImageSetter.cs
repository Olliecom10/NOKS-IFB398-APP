using UnityEngine;
using UnityEngine.UI;

public class ImageSetter : MonoBehaviour
{
    public RawImage rawImage; // Reference to the RawImage component
    public static int setter;
    
    public void ColourBondFence()
    {
        setter = 1;
    }
    public void ColourBondFenceRemove()
    {
        setter = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
            if (rawImage != null && setter == 1)
            {
                // Get the TextureSelection script from the scene
                TextureSelection textureSelection = FindObjectOfType<TextureSelection>();

                if (textureSelection != null && textureSelection.selectedTexture != null)
                {
                    // Assign the selected texture to the RawImage
                    rawImage.texture = textureSelection.selectedTexture;
                }
                else
                {
                    Debug.LogError("TextureSelection script or selected texture not found.");
                }
            }
    }

    

}