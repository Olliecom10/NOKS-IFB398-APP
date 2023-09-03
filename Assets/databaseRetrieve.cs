using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;

public class databaseRetrieve : MonoBehaviour
{
    private SQLiteConnection connection;

    public class RetrievingTestItems
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
        string databasePath = System.IO.Path.Combine(Application.dataPath, "SQLite_Python.db");
        connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        //Texture2D imageTexture = ConvertBytesToTexture(item.Image);
        RetrieveData();
    }

    private void RetrieveData()
    {
        // Query the database and retrieve items from the "Demo" table
        var items = connection.Table<RetrievingTestItems>().ToList();

        // Process and use the retrieved data
        foreach (var item in items)
        {
            Debug.Log($"ID: {item.id}, Name: {item.name}, Price: {item.price}, Status: {item.status}");

            // Convert and use the image data
            Texture2D imageTexture = ConvertBytesToTexture(item.image);
            // Display the image or do whatever you need
        }
    }

    private Texture2D ConvertBytesToTexture(byte[] bytes)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        return texture;
    }
}