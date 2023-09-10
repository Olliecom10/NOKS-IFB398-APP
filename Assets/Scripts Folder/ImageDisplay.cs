using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLite4Unity3d;
using System.Linq;

public class ImageDisplay : MonoBehaviour
{
    private SQLiteConnection connection;
    public Image imageUIElement; // Assign your Image UI component in the Inspector

    public class SqliteDb_developers_test
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public string status { get; set; }
        public byte[] image { get; set; }
    }

    private void Start()
    {
        // Set up the database connection
        string databasePath = System.IO.Path.Combine(Application.dataPath, "SQLite_Python.db");
        connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        // Retrieve and display image data from the database
        RetrieveAndDisplayImageData();
    }

    private void RetrieveAndDisplayImageData()
    {
        // Query the database and retrieve items
        var items = connection.Table<SqliteDb_developers_test>().ToList();

        foreach (var item in items)
        {
            Debug.Log($"ID: {item.id}, Name: {item.name}, Price: {item.price}, Status: {item.status}");

            Texture2D imageTexture = ConvertBytesToTexture(item.image);
            DisplayImage(imageTexture);
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


