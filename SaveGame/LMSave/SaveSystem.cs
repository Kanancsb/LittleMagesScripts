using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SavePlayer(PlayerKnowledge player){
        // Create a binary formatter for serialization
        BinaryFormatter formatter = new BinaryFormatter();

        // Define the save file path
        string path = Application.persistentDataPath + "/player.save";

        // Create a file stream to write the data
        FileStream stream = new FileStream(path, FileMode.Create);

        // Create a new PlayerData object with the player's data
        PlayerData data = new PlayerData(player);

        // Serialize the data and write it to the stream
        formatter.Serialize(stream, data);

        // Close the stream
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        // Define the save file path
        string path = Application.persistentDataPath + "/player.save";

        if(File.Exists(path)){
            // Create a binary formatter for deserialization
            BinaryFormatter formatter = new BinaryFormatter();

            // Open the file stream to read the data
            FileStream stream = new FileStream(path, FileMode.Open);

            // Deserialize the data and cast it to PlayerData object
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            // Close the stream
            stream.Close();
            
            // Return the deserialized data
            return data;
        }else{
            // If the save file does not exist, log an error and return null
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
