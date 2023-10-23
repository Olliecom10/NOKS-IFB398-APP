using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount8 : MonoBehaviour
{
    public static int countSFPCC;
    public TextMeshProUGUI Total_8;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextSFPCC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCount()
    {
        countSFPCC = 0;
    }

    public void UpdateScoreTextSFPCC()
    {
        Total_8.text = countSFPCC.ToString();
    }

    public void AddCountSFPCC()
    {
        countSFPCC++;
        UpdateScoreTextSFPCC();
    }

    public void SubtractCountSFPCC()
    {
        

        if (countSFPCC < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countSFPCC--;
            UpdateScoreTextSFPCC();
        }
    }
}
