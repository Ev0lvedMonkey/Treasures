using UnityEngine;

public class ServiceTest : MonoBehaviour, IService
{
    public int SecretNumber { get; private set; }

    private void Start()
    {
        SecretNumber = Random.Range(0,10);
    }
}
