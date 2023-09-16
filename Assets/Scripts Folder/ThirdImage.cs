using UnityEngine;
using System.Linq;
using SQLite4Unity3d;

public class ThirdImage : MonoBehaviour
{
    private SQLiteConnection dbConnection; // Your SQLite database connection
    private int targetEntryId = 3; // ID of the third entry you want to retrieve

    [Table("Gate_Fence_Database")]
    public class Gate_Fence_Database
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public byte[] image { get; set; }
    }

    void Start()
    {
        // Set the path to your SQLite database file
        string databasePath = Application.dataPath + "/Ezee_Industries.db";

        // Initialize the database connection
        dbConnection = new SQLiteConnection(databasePath);

        // Fetch and display the third image
        FetchAndDisplayImage();
    }

    void FetchAndDisplayImage()
    {
        try
        {
            // Retrieve the third entry from the database
            Gate_Fence_Database data = dbConnection.Table<Gate_Fence_Database>()
                .Where(entry => entry.id == targetEntryId)
                .FirstOrDefault();

            if (data != null)
            {
                // Convert the image data to a texture
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(data.image);

                // Display the texture on a GameObject
                Renderer renderer = GetComponent<Renderer>();
                Material material = new Material(Shader.Find("Standard")); // Choose an appropriate shader
                material.mainTexture = texture;
                renderer.material = material;
            }
            else
            {
                Debug.LogError("Entry not found in the database.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error fetching and displaying image: " + e.Message);
        }
    }

    void OnDestroy()
    {
        // Close the database connection when the script is destroyed
        if (dbConnection != null)
        {
            dbConnection.Close();
        }
    }
}
