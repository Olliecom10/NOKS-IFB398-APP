using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.UI;
using TMPro;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public ARPlacementInteractable placementInteractable;
    public TextMeshPro mText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI textMeshPro;
    public float tPrice = 0;
    public static float tempTPrice;
    public static float tempTDistance;
    public static string SuserInput;
    public TMP_Text canvasText;
    public static int SetHeight;


    // Start is called before the first frame update
    void Start()
    {
        placementInteractable.objectPlaced.AddListener(DrawLine);
    }
    
    public void ReadInput(TMP_InputField userinput)
    {
        SuserInput = userinput.text;        
    }

    void DrawLine(ARObjectPlacementEventArgs args)
    {   
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, args.placementObject.transform.position);
        
        float fencePriceMeter = float.Parse(SuserInput);

        if (lineRenderer.positionCount > 1)
        {
            Vector3 firstPoint = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
            Vector3 secondPoint = lineRenderer.GetPosition(lineRenderer.positionCount - 2);
            float distance = Vector3.Distance(firstPoint, secondPoint);
            
            float tempPrice = ((fencePriceMeter * distance) + tPrice);
            tempTDistance = tempTDistance + distance;
            tPrice = tempPrice;
            

            TextMeshPro distanceText = Instantiate(mText);
            distanceText.text = "" + distance;

            Vector3 vectorDirection = (secondPoint - firstPoint);
            Vector3 norm = args.placementObject.transform.up;

            Vector3 update = Vector3.Cross(vectorDirection, norm).normalized;
            Quaternion rotat = Quaternion.LookRotation(-norm, update);

            distanceText.transform.rotation = rotat;
            distanceText.transform.position = (firstPoint + vectorDirection * 0.5f) + update * 0.05f;

            

        }
    }




    public void Height1200()
    {
        SetHeight = 1;
    }

    public void Height1500()
    {
        SetHeight = 2;
    }

    public void Height1800()
    {
        SetHeight = 3;
    }

    public void Height2100()
    {
        SetHeight = 4;
    }

    public void ResetChoice()
    {
        SetHeight = 0;
    }

    public static float ToSingle(double value)
    {
        return (float)value;
    }

    public void Mat1Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 56;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 66;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 76;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 96;
        }
        
    }

    public void Mat1Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 56;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 66;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 76;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 96;
        }
    }



    public void Mat2Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 35;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 45;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 55;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 75;
        }

    }

    public void Mat2Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 35;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 45;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 55;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 75;
        }
    }

    public void Mat3Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 56;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 66;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 76;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 96;
        }

    }

    public void Mat3Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 56;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 66;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 76;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 96;
        }
    }



    public void Mat4Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 122;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 132;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 152;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 162;
        }

    }

    public void Mat4Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 122;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 132;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 152;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 162;
        }
    }


    public void Mat5Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + ToSingle(99.80);
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 115;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 130;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 145;
        }

    }

    public void Mat5Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - ToSingle(99.80);
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 115;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 130;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 145;
        }
    }

    public void Mat6Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 56;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 66;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 76;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 96;
        }

    }

    public void Mat6Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 56;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 66;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 76;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 96;
        }
    }

    public void Mat7Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 35;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 45;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 55;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 75;
        }

    }

    public void Mat7Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 35;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 45;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 55;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 75;
        }
    }



    public void Mat8Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + ToSingle(8.50);
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + ToSingle(8.50);
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + ToSingle(8.50);
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + ToSingle(8.50);
        }

    }

    public void Mat8Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - ToSingle(8.50);
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - ToSingle(8.50);
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - ToSingle(8.50);
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - ToSingle(8.50);
        }
    }


    public void Mat9Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + ToSingle(6.50);
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + ToSingle(6.50);
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + ToSingle(6.50);
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + ToSingle(6.50);
        }

    }

    public void Mat9Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - ToSingle(6.50);
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - ToSingle(6.50);
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - ToSingle(6.50);
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - ToSingle(6.50);
        }
    }
    public void Mat10Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 11;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 11;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 11;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 11;
        }

    }

    public void Mat10Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 11;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 11;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 11;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 11;
        }
    }


    public void Mat11Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 1800;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 1800;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 1800;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 1800;
        }

    }

    public void Mat11Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 1800;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 1800;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 1800;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 1800;
        }
    }


    public void Mat12Add()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice + 1280;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice + 1280;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice + 1280;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice + 1280;
        }

    }

    public void Mat12Remove()
    {
        if (SetHeight == 1)
        {
            tempTPrice = tempTPrice - 1280;
        }
        else if (SetHeight == 2)
        {
            tempTPrice = tempTPrice - 1280;
        }
        else if (SetHeight == 3)
        {
            tempTPrice = tempTPrice - 1280;
        }
        else if (SetHeight == 4)
        {
            tempTPrice = tempTPrice - 1280;
        }
    }



    public void TotalPriceUpdate()
    {
        tempTPrice = Mathf.Round(tPrice * 100.0f) * 0.01f;
        buttonText.text = $"Total Price: ${tempTPrice}";
    }

    public void resetPriceMeasure()
    {
        tempTPrice = 0;
        tempTDistance = 0;
    }

    

    public void UpdateFinalPrice()
    {
        float tempDistance = Mathf.Round(tempTDistance * 100.0f) * 0.01f;
        textMeshPro.text = $"Final Price: ${tempTPrice} \nFinal Distance: {Mathf.Round(tempDistance * 100.0f) * 0.01f} Metres";
    }


}