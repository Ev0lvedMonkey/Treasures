using UnityEngine;
using Zenject;

internal class ObjectMoverExample : MonoBehaviour
{
    private float moveSpeed = 10f;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private AbstarctSpawner _spawner;

    private void Update()
    {
        float horizontalAxis = Input.GetAxis(Horizontal);
        float verticalAxis = Input.GetAxis(Vertical);
        var moveDir = new Vector3(horizontalAxis, verticalAxis, 0);
        transform.Translate(moveDir * (Time.deltaTime * moveSpeed));
        if (Input.GetKeyDown(KeyCode.Q))
            _spawner.Spawn();
    }

    [Inject]
    private void Construct(AbstarctSpawner spawner)
    {
        _spawner = spawner;
        Debug.Log("Inject succses");
    }
}
