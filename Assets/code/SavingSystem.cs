using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingSystem
{
    public static string path = Application.persistentDataPath + "/E.yomama";//insert file name in quotes
    public static void SaveUser()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        SavedData data = new SavedData();

        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static SavedData LoadUser ()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            if(stream.Length==0)
            {
                File.Delete(path);
                return null;
            }
            SavedData data = formatter.Deserialize(stream) as SavedData;
            stream.Close();
            return data;
        }

        else
        {
            Debug.Log("Save file not found in "+ path);
            return null;
        }
    }
}
