using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalCount5 : MonoBehaviour
{

    public static int countCBP;
    public TextMeshProUGUI Total_5;
    public TextMeshProUGUI Mat5;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextCBP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSummaryText()
    {
        Mat5.text = $"Colourbond Panel x {countCBP}";
    }

    public void RemoveCount()
    {
        countCBP = 0;
    }

    public void UpdateScoreTextCBP()
    {
        Total_5.text = countCBP.ToString();
    }

    public void AddCountCBP()
    {
        countCBP++;
        UpdateScoreTextCBP();
    }

    public void SubtractCountCBP()
    {
        Debug.Log("SubtractCount called");

        if (countCBP < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countCBP--;
            UpdateScoreTextCBP();
        }
    }
}
