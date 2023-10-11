using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalCount : MonoBehaviour
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
        // Optionally update the score text in Update if needed.
    }

    void UpdateScoreText()
    {
        scoreText.text = count.ToString();
    }

    public void AddCount()
    {
        count++;
        UpdateScoreText();
    }

    public void SubtractCount()
    {
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