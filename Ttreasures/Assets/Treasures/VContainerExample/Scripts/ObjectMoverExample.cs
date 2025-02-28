using UnityEngine;
using VContainer;

internal class ObjectMoverExample : MonoBehaviour
{
    private const float MoveSpeed = 10f;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private AbstarctSpawner _spawner;


    private void Update()
    {
        float horizontalAxis = Input.GetAxis(Horizontal);
        float verticalAxis = Input.GetAxis(Vertical);
        var moveDir = new Vector3(horizontalAxis, verticalAxis, 0);
        transform.Translate(moveDir * (Time.deltaTime * MoveSpeed));
        if (Input.GetKeyDown(KeyCode.Q))
            _spawner.Spawn();
    }

    [Inject]
    public void Construct(AbstarctSpawner spawner)
    {
        _spawner = spawner;
        Debug.Log("Inject succses");
    }
}
