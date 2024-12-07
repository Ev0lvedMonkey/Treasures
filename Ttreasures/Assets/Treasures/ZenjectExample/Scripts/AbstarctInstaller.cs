using UnityEngine;
using Zenject;

internal class AbstarctInstaller : MonoInstaller
{
    [SerializeField] private AbstarctSpawner _abstarctSpawner;

    public override void InstallBindings()
    {
        Container.Bind<AbstarctSpawner>().FromInstance(_abstarctSpawner);
    }
}