using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager
{
    private const string PrefabsFilePath = "DialogModule/Prefabs/";

    private static readonly Dictionary<Type, string> PrefabsDictionary = new()
    {
        {typeof(FirstDialog),"FirstDialog"},
        {typeof(SecondDialog),"SecondDialog"},
    };

    internal static T ShowDialog<T>() where T : V1Dialog
    {
        var gameObject = GetPrefabByType<T>();
        if (gameObject == null)
        {
            Debug.LogError("Show window - object not found");
            return null;
        }
        return GameObject.Instantiate(gameObject);
    }

    private static T GetPrefabByType<T>() where T : V1Dialog
    {
        string prefabName = PrefabsDictionary[typeof(T)];

        if (string.IsNullOrEmpty(prefabName))
            Debug.Log($"missed prefab by type {typeof(T)}");

        string path = PrefabsFilePath + prefabName;

        var dialogObj = Resources.Load<T>(path);

        if (dialogObj == null)
            Debug.Log($"dialog not loaded. Path:\n{path}");

        return dialogObj;
    }
}
