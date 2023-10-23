using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount12 : MonoBehaviour
{
    public static int countAK;
    public TextMeshProUGUI Total_12;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextAK();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCount()
    {
        countAK = 0;
    }

    public void UpdateScoreTextAK()
    {
        Total_12.text = countAK.ToString();
    }

    public void AddCountAK()
    {
        countAK++;
        UpdateScoreTextAK();
    }

    public void SubtractCountAK()
    {
        Debug.Log("SubtractCount called");

        if (countAK < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countAK--;
            UpdateScoreTextAK();
        }
    }
}
