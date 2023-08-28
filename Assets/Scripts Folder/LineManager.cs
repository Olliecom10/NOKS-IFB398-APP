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

    // Start is called before the first frame update
    void Start()
    {
        placementInteractable.objectPlaced.AddListener(DrawLine);
    }


    void DrawLine(ARObjectPlacementEventArgs args)
    {
        lineRenderer.positionCount++;

        lineRenderer.SetPosition(lineRenderer.positionCount - 1, args.placementObject.transform.position);

        if (lineRenderer.positionCount > 1)
        {
            Vector3 firstPoint = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
            Vector3 secondPoint = lineRenderer.GetPosition(lineRenderer.positionCount - 2);
            float distance = Vector3.Distance(firstPoint, secondPoint);

            float fencePriceMeter = 100;
            float tempPrice = ((fencePriceMeter * distance) + tPrice);
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

    public void TotalPriceUpdate()
    {
        buttonText.text = $"Total Price: {tPrice}";
    }


}
