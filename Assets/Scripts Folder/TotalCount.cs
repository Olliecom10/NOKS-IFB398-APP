using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount : MonoBehaviour
{
    public static int count;
    public TextMeshProUGUI Total_1;
    public TextMeshProUGUI Mat1;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCount()
    {
        count = 0;
    }

    public void UpdateSummaryText()
    {
        Mat1.text = $"65 x 65 ColourBond Post x {count}";
    }

    public void UpdateScoreText()
    {
        Total_1.text = count.ToString();
    }

    public void AddCount()
    {
        count++;
        UpdateScoreText();
    }

    public void SubtractCount()
    {
        Debug.Log("SubtractCount called");

        if (count < 1)
        {
           Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            count--;
            UpdateScoreText();
        }
    }
}