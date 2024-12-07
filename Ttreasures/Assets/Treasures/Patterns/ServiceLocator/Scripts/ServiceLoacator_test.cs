using UnityEngine;

internal class ServiceLoacator_test : MonoBehaviour, IService
{
    [SerializeField] private ServiceTest _testService;

    //Bad example, but im lazy

    private void Start()
    {
        Debug.Log($"{ServiceLocator.Current.Get<ServiceTest>().SecretNumber}");
    }


    private void Awake()
    {
        RegisterServices();
    }

    private void RegisterServices()
    {
        ServiceLocator.Inizialize();
        ServiceLocator.Current.Register(_testService);
    }
}
