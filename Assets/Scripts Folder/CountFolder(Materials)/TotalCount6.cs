using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalCount6 : MonoBehaviour
{

    public static int countIP;
    public TextMeshProUGUI Total_6;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextIP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScoreTextIP()
    {
        Total_6.text = countIP.ToString();
    }

    public void AddCountIP()
    {
        countIP++;
        UpdateScoreTextIP();
    }

    public void SubtractCountIP()
    {
        Debug.Log("SubtractCount called");

        if (countIP < 1)
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }
        else
        {
            countIP--;
            UpdateScoreTextIP();
        }
    }

}
