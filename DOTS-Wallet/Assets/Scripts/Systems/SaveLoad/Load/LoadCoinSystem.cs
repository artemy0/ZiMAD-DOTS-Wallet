using Unity.Entities;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct LoadCoinSystem : ISystem
{
    // TODO Inject the dependency on the SaveLoad service

    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<CoinComponent>();
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var coinComponent = SystemAPI.GetSingletonRW<CoinComponent>();
        coinComponent.ValueRW.Balance = SaveLoadCurrencyToPlayerPrefsService.Load(CurrencyConstants.COIN);
    }
}