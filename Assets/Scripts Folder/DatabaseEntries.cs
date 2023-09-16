using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class DatabaseEntries : MonoBehaviour
{
    private SQLiteConnection connection;
    public Image imageUIElement;
    //public Text textUIElement;
    //public Text textName; // Reference to the Text for displaying the name.
    //public Text textPrice; // Reference to the Text for displaying the price.
    //public Text textCategory; // Reference to the Text for displaying the category.

    public TextMeshProUGUI textName; // Reference to the Text for displaying the name.
    public TextMeshProUGUI textPrice; // Reference to the Text for displaying the price.
    public TextMeshProUGUI textCategory; // Reference to the Text for displaying the category.

    public GameObject DBDisplayEntries; // Reference to your UI template prefab.
    public Transform DatabaseEntriesContainer;

    public class Gate_Fence_Database
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; } //maybe float
        public string category { get; set; }
        public byte[] image { get; set; }
    }

    private void Start()
    {

        //string dbPath = Application.dataPath + "Ezee_Industries.db";
        //var connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        string dbPath = System.IO.Path.Combine(Application.dataPath, "Ezee_Industries.db");
        connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        var items = connection.Table<Gate_Fence_Database>().ToList();

        foreach (var item in items)
        {
            // Instantiate a new UI element from the prefab
            GameObject uiElement = Instantiate(DBDisplayEntries, DatabaseEntriesContainer);

            // Populate the UI elements (e.g., image, text fields) with data from 'item'
            Image image = uiElement.GetComponentInChildren<Image>();

            // Get references to the Text elements for name, price, and category
            TextMeshProUGUI nameText = uiElement.transform.Find("DB_Name").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI priceText = uiElement.transform.Find("DB_Price").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI categoryText = uiElement.transform.Find("DB_Category").GetComponent<TextMeshProUGUI>(); // Was Text instead of TextMeshProUGUI

            // Load and display the image using your functions
            Texture2D imageTexture = ConvertBytesToTexture(item.image);
            image.sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), Vector2.zero);

            // Populate text elements
            nameText.text = "Name: " + item.name;
            priceText.text = "Price: " + item.price;
            categoryText.text = "Category: " + item.category;
        }


    }
    private Texture2D ConvertBytesToTexture(byte[] bytes)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return texture;
    }

    private void DisplayImage(Texture2D texture)
    {
        imageUIElement.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}


//foreach (var item in items)
//{
//    // Instantiate a new UI element from the prefab
//    GameObject uiElement = Instantiate(DBDisplayEntries, DatabaseEntriesContainer);

//    // Populate the UI elements (e.g., image, text fields) with data from 'item'
//    Image image = uiElement.GetComponentInChildren<Image>();
//    Text nameText = uiElement.GetComponentInChildren<Text>();
//    Text priceText = uiElement.GetComponentInChildren<Text>();
//    Text categoryText = uiElement.GetComponentInChildren<Text>();

//    // Load and display the image using your functions
//    Texture2D imageTexture = ConvertBytesToTexture(item.image);
//    image.sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), Vector2.zero);

//    // Populate text elements
//    nameText.text = "Name: " + item.name;
//    priceText.text = "Price " + item.price;
//    categoryText.text = "Category: " + item.category;
//}

//private void Start()
//{
//    // Define the database connection
//    string dbPath = Application.dataPath + "Ezee_Industries.db";
//    var connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

//    // Retrieve data from the YourTable table
//    var items = connection.Table<Gate_Fence_Database>().ToList();

//    // Use the retrieved data as needed
//    foreach (var item in items)
//    {
//        //Debug.Log("ID: " + item.id + ", Name: " + item.name + ", Price: " + item.price + ", Category: " + item.category);
//        // Populate your UI elements here
//        string formattedName = "Name: " + item.name;
//        string formattedPrice = "Price: " + item.price;
//        string formattedCategory = "Category: " + item.category;

//        textUIElement.text = formattedName + "\n" + formattedCategory;

//        Texture2D imageTexture = ConvertBytesToTexture(item.image); // Assuming item.ImageBytes contains the image data.
//        DisplayImage(imageTexture);


//        Debug.Log(formattedName);
//        Debug.Log(formattedCategory);
//    }


//    // Close the database connection
//    connection.Close();
//}
