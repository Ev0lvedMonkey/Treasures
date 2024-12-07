using UnityEngine;

internal class ServiceTest : MonoBehaviour, IService
{
    internal int SecretNumber { get; private set; }

    private void Start()
    {
        SecretNumber = Random.Range(0,10);
    }
}
