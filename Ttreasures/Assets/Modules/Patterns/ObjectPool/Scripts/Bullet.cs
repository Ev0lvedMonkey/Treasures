using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private const float BulletLifeTime = 3f;
    private const float BulletSpeed = 1f;

    private void OnValidate()
    {
        if (_rb == null)
        {
            if (TryGetComponent(out Rigidbody2D rb))
                _rb = rb;
        }
    }

    public void Init()
    {
        ResetState();
        StartCoroutine(Spawn());
    }

    private void ResetState()
    {
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0f;
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.right * BulletSpeed;
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(BulletLifeTime);
        EventManager.InvokeRealeseBullet(this);
    }
}
