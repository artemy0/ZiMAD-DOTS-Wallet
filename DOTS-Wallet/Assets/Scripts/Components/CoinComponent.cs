using Unity.Entities;

public struct CoinComponent : IComponentData
{
    public int Balance;
}

public struct AddCoinTag : IComponentData
{
    // TODO Add operation value
}

public struct RemoveCoinTag : IComponentData
{
    // TODO Add operation value
}