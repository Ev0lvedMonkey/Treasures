using UnityEngine;
using UnityEngine.Pool;

internal class UnityPoolExample : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _prefab;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        GenerateNewPool();

        EventManager.TransferSpentBulletEvent.AddListener(Dispose);
    }

    private void GenerateNewPool()
    {
        _bulletPool = new ObjectPool<Bullet>(
                    OnCreateBullet,
                    OnGetBullet,
                    OnReleaseBullet,
                    OnBulletDestroy,
                    false,
                    5,
                    10
                );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Spawn();
    }

    private void Spawn()
    {
        var bullet = _bulletPool.Get();
        bullet.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);
        bullet.Init();
        Debug.Log($"Spawned {bullet.name}");
    }

    private void Dispose(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }

    private Bullet OnCreateBullet()
    {
        return GameObject.Instantiate(_prefab);
    }

    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
