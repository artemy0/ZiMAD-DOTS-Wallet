using Unity.Entities;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(AddCoinTagSystem))]
public partial struct SaveCoinSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (var walletAspect in SystemAPI.Query<WalletAspect>().WithAny<AddCoinTag, RemoveCoinTag>())
        {
            SaveLoadCurrencyToPlayerPrefsService.Save(
                CurrencyConstants.COIN, walletAspect.CoinBalance);

            return;
        }
    }
}