using Unity.Entities;

public readonly partial struct WalletAspect : IAspect
{
    public readonly Entity Entity;

    private readonly RefRW<CoinComponent> coinComponent;
    private readonly RefRW<CrystalComponent> crystalComponent;

    // TODO Add Init, Add, Remove methods and readonly Property?
    public int CoinBalance
    {
        get => coinComponent.ValueRO.Balance;
        set => coinComponent.ValueRW.Balance = value;
    }

    public int CrystalBalance
    {
        get => crystalComponent.ValueRO.Balance;
        set => crystalComponent.ValueRW.Balance = value;
    }
}