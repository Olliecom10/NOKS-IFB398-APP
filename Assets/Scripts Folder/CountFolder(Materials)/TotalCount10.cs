using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalCount10 : MonoBehaviour
{
    public static int countPCTS;
    public TextMeshProUGUI Total_10;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextPCTS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCount()
    {
        countPCTS = 0;
    }

    public void UpdateScoreTextPCTS()
    {
        Total_10.text = countPCTS.ToString();
    }

    public void AddCountPCTS()
    {
        countPCTS++;
        UpdateScoreTextPCTS();
    }

    public void SubtractCountPCTS()
    {
        Debug.Log("SubtractCount called");

        if (countPCTS < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countPCTS--;
            UpdateScoreTextPCTS();
        }
    }
}
