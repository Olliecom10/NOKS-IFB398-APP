using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;

public class RetrievingDatabase : MonoBehaviour
{
    private SQLiteConnection connection;

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
        string databasePath = System.IO.Path.Combine(Application.dataPath, "SQLite_Python.db");
        connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        //Texture2D imageTexture = ConvertBytesToTexture(item.Image);
        RetrieveData();
    }

    private void RetrieveData()
    {
        // Query the database and retrieve items from the "Demo" table
        var items = connection.Table<SqliteDb_developers_test>().ToList();

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


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using SQLite4Unity3d;

//public class RetrievingDatabase : MonoBehaviour
//{
//    private SQLiteConnection connection;

//    private void Start()
//    {
//        connection = new SQLiteConnection(Application.dataPath + "/SQLite_Python.db" + SQLiteOpenFlags.ReadWrite) | SQLiteOpenFlags.Create);

//        Texture2D imageTexture = ConvertBytesToTexture(item.Image);
//    }

//    private void RetrieveData()
//    {
//        // Query the database and retrieve items from the "Demo" table
//        var items = connection.Table<SqliteDb_developers_test>().ToList();

//        // Process and use the retrieved data
//        foreach (var item in items)
//        {
//            Debug.Log($"ID: {item.ID}, Name: {item.Name}, Price: {item.Price}, Status: {item.Status}");

//            // Convert and use the image data
//            Texture2D imageTexture = ConvertBytesToTexture(item.Image);
//            // Display the image or do whatever you need
//        }
//    }

//    private Texture2D ConvertBytesToTexture(byte[] bytes)
//    {
//        Texture2D texture = new Texture2D(2, 2);
//        texture.LoadImage(bytes);
//        return texture;
//    }
//}
