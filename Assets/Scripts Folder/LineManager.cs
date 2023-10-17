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
    public Text text;
    public float tPrice = 0;
    public static float tempTPrice;
    public static string SuserInput;
    public TMP_Text canvasText;
    public static int steelPost65;

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
            tPrice = Mathf.Round(tempPrice * 100.0f) * 0.01f;;
            

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
   
    public void SteelPostAdd()
    {
        tempTPrice = tempTPrice + 300;
        steelPost65 = steelPost65 + 1;
        text.text = $"{steelPost65}";
    }

    public void SteelPostRemove()
    {
        tempTPrice = tempTPrice - 300;
        steelPost65 = steelPost65 - 1;
        text.text = $"{steelPost65}";

    }

    public void TotalPriceUpdate()
    {
        buttonText.text = $"Total Price: ${tPrice}";
        
        tempTPrice = tPrice;
    }

    public void resetPrice()
    {

    }

    

    public void UpdateFinalPrice()
    {
        buttonText.text = $"The final price is: ${tempTPrice}";
    }


}