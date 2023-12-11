using Unity.Entities;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(AddCrystalTagSystem))]
public partial struct SaveCrystalSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (var walletAspect in SystemAPI.Query<WalletAspect>().WithAny<AddCrystalTag, RemoveCrystalTag>())
        {
            SaveLoadCurrencyToPlayerPrefsService.Save(
                CurrencyConstants.CRYSTAL, walletAspect.CrystalBalance);
            
            return;
        }
    }
}