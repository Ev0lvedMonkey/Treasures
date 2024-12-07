using System;
using System.Collections.Generic;
using UnityEngine;

internal class ServiceLocator 
{
    private ServiceLocator() { }

    private readonly Dictionary<string, IService> _services = new();

    public static ServiceLocator Current { get; private set; }

    public static void Inizialize()
    {
        Current = new ServiceLocator();
    }

    internal T Get<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            Debug.LogError($"{key} not registred with {GetType().Name}");
            throw new InvalidOperationException();
        }
        return (T)_services[key];
    }

    internal void Register<T>(T service) where T : IService
    {
        string key = typeof(T).Name;
        if (_services.ContainsKey(key))
        {
            Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
            return;
        }
        _services.Add(key, service);
    }

    internal void Unregister<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            Debug.LogError(
                $"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        _services.Remove(key);
    }
}
