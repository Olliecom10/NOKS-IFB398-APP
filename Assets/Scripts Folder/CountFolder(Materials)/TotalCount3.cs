using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount3 : MonoBehaviour
{

    public static int countSSP;
    public TextMeshProUGUI Total_3;
    public TextMeshProUGUI Mat3;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextSSP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSummaryText()
    {
        Mat3.text = $"Standard Slat Panel x {countSSP}";
    }

    public void RemoveCount()
    {
        countSSP = 0;
    }

    public void UpdateScoreTextSSP()
    {
        Total_3.text = countSSP.ToString();
    }

    public void AddCountSSP()
    {
        countSSP++;
        UpdateScoreTextSSP();
    }

    public void SubtractCountSSP()
    {
        Debug.Log("SubtractCount called");

        if (countSSP < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countSSP--;
            UpdateScoreTextSSP();
        }
    }
}
