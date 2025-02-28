using VContainer;
using VContainer.Unity;

public class AdressableSceneLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<DialogLoader>(Lifetime.Singleton);
    }
}
