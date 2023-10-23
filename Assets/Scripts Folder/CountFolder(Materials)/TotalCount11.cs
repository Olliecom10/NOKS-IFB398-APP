using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount11 : MonoBehaviour
{
    public static int countSAK;
    public TextMeshProUGUI Total_11;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextSAK();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreTextSAK()
    {
        Total_11.text = countSAK.ToString();
    }

    public void AddCountSAK()
    {
        countSAK++;
        UpdateScoreTextSAK();
    }

    public void SubtractCountSAK()
    {
        Debug.Log("SubtractCount called");

        if (countSAK < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countSAK--;
            UpdateScoreTextSAK();
        }
    }
}
