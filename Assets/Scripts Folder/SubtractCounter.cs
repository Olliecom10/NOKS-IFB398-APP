using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtractCounter : MonoBehaviour
{
    public int count;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreText.text = count.ToString();
    }

    public void SubtractCount()
    {
        Debug.Log("SubtractCount called"); // Add this line for debugging

        if (count > 0)
        {
            count--;
            UpdateScoreText();
        }
        else
        {
            Debug.LogWarning("Count is already zero. Cannot subtract.");
        }

    }
}
