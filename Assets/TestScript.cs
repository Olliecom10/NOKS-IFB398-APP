using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestScript : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI categoryText;

    private void Start()
    {
        // Replace these with your test data or logic for database retrieval
        string testName = "Product A";
        string testPrice = "$19.99";
        string testCategory = "Electronics";

        // Display the test data on the UI elements
        nameText.text = "Name: " + testName;
        priceText.text = "Price: " + testPrice;
        categoryText.text = "Category: " + testCategory;
    }
}
