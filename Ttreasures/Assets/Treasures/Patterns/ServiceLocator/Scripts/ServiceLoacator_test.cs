using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IService
{
    [SerializeField] private ServiceTest _testService;

    //Bad example, but im lazy

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
