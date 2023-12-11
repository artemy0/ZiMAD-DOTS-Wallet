using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(AddCoinTagSystem))]
public partial struct DisplayCoinSystem : ISystem
{
    private const string DISPLAYING_FORMAT = "Coin.Balance = {0}";
    
    // TODO Inject the dependency on the UI service
    
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
            Debug.Log(string.Format(DISPLAYING_FORMAT, walletAspect.CoinBalance));
        }
    }
}