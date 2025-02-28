using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace VContainerExample
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private AbstarctSpawner _abstarctSpawner;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_abstarctSpawner);
        }
    }
}

