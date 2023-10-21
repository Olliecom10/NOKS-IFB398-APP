using UnityEngine;
using System.Collections.Generic;
using SQLite4Unity3d;
using System.Linq;
using System;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class DesktopDatabase : MonoBehaviour
{
    public GameObject DBDisplayEntries;
    public Transform contentPanel;
    public GameObject DatabaseEntriesContainer;
    private SQLiteConnection connection;

    [Table("Gate_Fence_Database")] // Add this line to specify the table name
    public class Gate_Fence_Database
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string category { get; set; }
        public byte[] image { get; set; }
    }

    private List<Gate_Fence_Database> productsList = new List<Gate_Fence_Database>(); // Declare the productsList variable

    private IEnumerator Start()
    {
        // Define the path to your database file in the StreamingAssets folder
        string databasePath = System.IO.Path.Combine(Application.streamingAssetsPath, "Ezee_Industries.db");

        // Set the databasePath to the path in the persistent data path
        string persistentDatabasePath = System.IO.Path.Combine(Application.persistentDataPath, "Ezee_Industries.db");

        // Check if the file exists in the persistent data path (cache)
        if (!System.IO.File.Exists(persistentDatabasePath))
        {
            // Create a UnityWebRequest to download the file
            UnityWebRequest webRequest = UnityWebRequest.Get(databasePath);

            // Send the web request and wait for it to complete
            yield return webRequest.SendWebRequest();

            // Check if there was an error while downloading
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download database: " + webRequest.error);
                yield break; // Exit the coroutine if there was an error
            }

            // Save the downloaded bytes to the persistent data path
            System.IO.File.WriteAllBytes(persistentDatabasePath, webRequest.downloadHandler.data);
        }

        // Open a connection to the SQLite database
        // changed persistentDatabasePath to database path
        connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        connection.CreateTable<Gate_Fence_Database>();

        try
        {
            // Retrieve data from the database and populate the productsList
            List<Gate_Fence_Database> dbProducts = connection.Table<Gate_Fence_Database>().ToList();
            productsList = dbProducts; // Assign dbProducts to productsList

            Debug.Log("Number of products: " + productsList.Count);

            // Loop through productsList to create UI elements
            foreach (Gate_Fence_Database product in productsList)
            {
                if (product.category.Contains("Gate"))
                {
                    Debug.Log("Testing for each starting");
                    // Instantiate the prefab as a child of the DatabaseEntriesContainer
                    GameObject productInstance = Instantiate(DBDisplayEntries, DatabaseEntriesContainer.transform);

                    // Get references to UI elements
                    TextMeshProUGUI nameText = productInstance.transform.Find("DB_Name").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI priceText = productInstance.transform.Find("DB_Price").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI categoryText = productInstance.transform.Find("DB_Category").GetComponent<TextMeshProUGUI>();
                    Image productImage = productInstance.transform.Find("Image").GetComponent<Image>();

                    // Set text and image using product data
                    nameText.text = "Name: " + product.name;
                    priceText.text = "Price: " + product.price;
                    categoryText.text = "Category: " + product.category;

                    // Create a Texture2D from the byte[] image data
                    Texture2D tex = new Texture2D(2, 2);
                    tex.LoadImage(product.image);
                    productImage.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e.Message);
        }
    }
}

