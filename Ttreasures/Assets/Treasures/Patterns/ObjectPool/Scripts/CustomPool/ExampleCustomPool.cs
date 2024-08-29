using System.Collections.Generic;
using UnityEngine;

public class ExampleCustomPool : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _prefab;

    private readonly Dictionary<string, CustomObjectPool<Bullet>> _pools =
        new Dictionary<string, CustomObjectPool<Bullet>>();
    private const string BulletString = "Bullet";


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        EventManager.TransferSpentBulletEvent.AddListener(Dispose);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Spawn();
    }

    private void Spawn()
    {
        var pool = GetAccessibleBullet();

        var item = pool.Get();
        item.Init();
        item.transform.position = _spawnPoint.position;
        item.transform.rotation = Quaternion.identity;
        Debug.Log($"Spawned on pos {item.transform.position}\n Spawn pos {_spawnPoint.position}");
    }

    private void Dispose(Bullet obj)
    {
        var pool = GetAccessibleBullet();
        pool.Realease(obj);
    }

    private CustomObjectPool<Bullet> GetAccessibleBullet()
    {
        CustomObjectPool<Bullet> pool;

        if (!_pools.ContainsKey(BulletString))
        {
            pool = new CustomObjectPool<Bullet>(_prefab, 5);
            _pools.Add(BulletString, pool);
        }
        else
            pool = _pools[BulletString];
        return pool;
    }

}
