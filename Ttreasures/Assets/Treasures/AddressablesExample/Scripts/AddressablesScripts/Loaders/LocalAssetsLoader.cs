using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

internal class LocalAssetsLoader
{
    private GameObject _cachedObject;

    protected async Task<T> LoadInternal<T>(string assetID)
    {
        var handle = Addressables.InstantiateAsync(assetID);
        _cachedObject = await handle.Task;
        Type cachedObjectType = _cachedObject.GetType();
        if (_cachedObject.TryGetComponent(out T loadingObject) == false)
            throw new NullReferenceException($"Object of type {typeof(T)} is null. {cachedObjectType}");
        return loadingObject;
    }

    protected void UnloadInternal()
    {
        if (_cachedObject == null)
        {
            Debug.LogError($"CachedObject is null");
            return;
        }
        _cachedObject.SetActive(false);
        Addressables.ReleaseInstance(_cachedObject);
        _cachedObject = null;
    }
}
