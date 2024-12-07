using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class CustomObjectPool<T> where T: MonoBehaviour
{
    private T _prefab;
    private List<T> _objects;

    internal CustomObjectPool(T prefabs, int prewarmObjects)
    {
        _prefab = prefabs;
        _objects = new List<T>();

        for (int i = 0; i < prewarmObjects; i++)
        {
            var obj = GameObject.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _objects.Add(obj);
        }
    }

    internal T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled) ?? Create();
        obj.gameObject.SetActive(true);
        return obj;
    }

    internal T Create()
    {
        var obj = GameObject.Instantiate(_prefab);
        _objects.Add(obj);
        return obj;
    }

    internal void Realease(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
