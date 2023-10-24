using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalCount4 : MonoBehaviour
{

    public static int countOHSPP;
    public TextMeshProUGUI Total_4;
    public TextMeshProUGUI Mat4;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextOHSPP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSummaryText()
    {
        Mat4.text = $"100 x 100 Slat Panel Post x {countOHSPP}";
    }

    public void RemoveCount()
    {
        countOHSPP = 0;
    }

    public void UpdateScoreTextOHSPP()
    {
        Total_4.text = countOHSPP.ToString();
    }

    public void AddCountOHSPP()
    {
        countOHSPP++;
        UpdateScoreTextOHSPP();
    }

    public void SubtractCountOHSPP()
    {
        Debug.Log("SubtractCount called");

        if (countOHSPP < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countOHSPP--;
            UpdateScoreTextOHSPP();
        }
    }
}
