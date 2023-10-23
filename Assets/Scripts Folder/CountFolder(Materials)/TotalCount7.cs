using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount7 : MonoBehaviour
{
    public static int countCBR;
    public TextMeshProUGUI Total_7;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextCBR();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCount()
    {
        countCBR = 0;
    }

    public void UpdateScoreTextCBR()
    {
        Total_7.text = countCBR.ToString();
    }

    public void AddCountCBR()
    {
        countCBR++;
        UpdateScoreTextCBR();
    }

    public void SubtractCountCBR()
    {
        Debug.Log("SubtractCount called");

        if (countCBR < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countCBR--;
            UpdateScoreTextCBR();
        }
    }
}
