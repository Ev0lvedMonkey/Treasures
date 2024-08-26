using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomObjectPool<T> where T: MonoBehaviour
{
    private T _prefab;
    private List<T> _objects;

    public CustomObjectPool(T prefabs, int prewarmObjects)
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

    public T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj == null)
            obj = Create();

        obj.gameObject.SetActive(true);
        return obj;
    }

    public T Create()
    {
        var obj = GameObject.Instantiate(_prefab);
        _objects.Add(obj);
        return obj;
    }

    public void Realease(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
