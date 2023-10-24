using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount2 : MonoBehaviour
{

    public static int countCBFT;
    public TextMeshProUGUI Total_2;
    public TextMeshProUGUI Mat2;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextCBFT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSummaryText()
    {
        Mat2.text = $"50 x 50 Colourbond Post x {countCBFT}";
    }

    public void RemoveCount()
    {
        countCBFT = 0;
    }

    public void UpdateScoreTextCBFT()
    {
        Total_2.text = countCBFT.ToString();
    }

    public void AddCountCBFT()
    {
        countCBFT++;
        UpdateScoreTextCBFT();
    }

    public void SubtractCountCBFT()
    {


        if (countCBFT < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countCBFT--;
            UpdateScoreTextCBFT();
        }
    }
}
