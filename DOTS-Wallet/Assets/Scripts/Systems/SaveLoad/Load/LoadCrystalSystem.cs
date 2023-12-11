using Unity.Entities;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct LoadCrystalSystem : ISystem
{
    // TODO Inject the dependency on the SaveLoad service
    
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<CrystalComponent>();
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;

        var crystalComponent = SystemAPI.GetSingletonRW<CrystalComponent>();
        crystalComponent.ValueRW.Balance = SaveLoadCurrencyToPlayerPrefsService.Load(CurrencyConstants.CRYSTAL);
    }
}