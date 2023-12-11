using VContainer;
using VContainer.Unity;

public class LocalDIContainer : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // TODO Register UIService or I...Bridge To connect the UI and Systems
        // TODO Register ISaveLoadCurrencyService
    }
}
