using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JSonToFileStorageService : IStorageService
{
    public void Save(string key, object data, Action<bool> callback = null)
    {
        string path = BiuldPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }
        callback?.Invoke(true);
    }

    public void Load<T>(string key, Action<T> callback)
    {
        string path = BiuldPath(key);

        if (File.Exists(path))
        {
            using (var fileStream = new StreamReader(path))
            {
                var json = fileStream.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);

                callback?.Invoke(data);
            }
        }
        else
        {
            Debug.LogWarning($"File not found at path: {path}. Creating a new file with default data.");

            T defaultData = Activator.CreateInstance<T>();
            Save(key, defaultData);
            callback?.Invoke(defaultData);
        }
    }

    private string BiuldPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }

}
