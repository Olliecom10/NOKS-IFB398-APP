using UnityEngine;
using UnityEngine.UI;

public class TextureSelection : MonoBehaviour
{
    public Texture selectedTexture;

    public void SetSelectedTexture(Object textureObject)
    {
        // This method receives a UnityEngine.Object, which is passed by the Button component.
        // You should cast it to a Texture since you know it's a texture.
        selectedTexture = textureObject as Texture;
    }
}