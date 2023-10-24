using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalCount9 : MonoBehaviour
{
    public static int countFTPCC;
    public TextMeshProUGUI Total_9;
    public TextMeshProUGUI Mat9;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextFTPCC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCount()
    {
        countFTPCC = 0;
    }

    public void UpdateSummaryText()
    {
        Mat9.text = $"50 x 50 Powdercoated Cap x {countFTPCC}";
    }

    public void UpdateScoreTextFTPCC()
    {
        Total_9.text = countFTPCC.ToString();
    }

    public void AddCountFTPCC()
    {
        countFTPCC++;
        UpdateScoreTextFTPCC();
    }

    public void SubtractCountFTPCC()
    {
        Debug.Log("SubtractCount called");

        if (countFTPCC < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countFTPCC--;
            UpdateScoreTextFTPCC();
        }
    }
}

