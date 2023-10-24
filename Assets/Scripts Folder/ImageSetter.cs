using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSetter: MonoBehaviour
{
    public RawImage rawImage; // Reference to your Raw Image
    public Texture texture1;  // The texture to assign when setter = 1

    public static int setter; // Your variable to control texture assignment

    public void ColourBond()
    {
        setter = 1;
    }
    public void ColourBondRemove()
    {
        setter = 0;
    }

    // Update is called once per frame
    void Start()
    {
        if (setter == 1)
        {
            rawImage.texture = texture1; // Assign texture1 to the Raw Image
        }
        // Add more conditions for other values of 'setter' if needed.
    }
}