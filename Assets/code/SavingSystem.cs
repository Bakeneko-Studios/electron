using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Localization.Settings;

public static class SavingSystem
{
    public static string path = Application.persistentDataPath + "/user.data";//insert file name in quotes
    public static void SaveUser (UserData user)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        SavedData data = new SavedData(user);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static SavedData LoadUser ()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData data = formatter.Deserialize(stream) as SavedData;
            stream.Close();
            return data;

            if (Application.systemLanguage == SystemLanguage.Chinese) 
                GameObject.FindGameObjectWithTag("user data").GetComponent<UserData>().language = 1;
        }

        else
        {
            Debug.Log("Save file not found in "+ path);
            return null;
        }
    }
}
