using UnityEngine;
using VContainer;

public class DialogTestSpawner : MonoBehaviour
{
    [Inject] private IObjectResolver _resolver;
    public GameObject dialogTestPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var instance = Instantiate(dialogTestPrefab);
            _resolver.Inject(instance);
        }
    }
}
