using UnityEngine;
using System.IO;

static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "Data.txt";

    public static void Save(SaveData data)
    {
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveData LoadData()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveData data = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.LogError("FileDoesNotExist");
        }

        return data;
    }
}