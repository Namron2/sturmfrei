using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_System 
{
    public static void SaveNumber(int number)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/nombre.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Save_Data_Proto data = new Save_Data_Proto(number);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Save_Data_Proto LoadData()
    {
        string path = Application.persistentDataPath + "/nombre.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Save_Data_Proto data = formatter.Deserialize(stream) as Save_Data_Proto;

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
