using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
[UpdateAfter(typeof(LoadCoinSystem))]
public partial struct InitializationDisplayingWalletsCoinSystem : ISystem
{
    private const string DISPLAYING_FORMAT = "Coin.Balance = {0}";
    
    // TODO Inject the dependency on the UI service
    
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
        Debug.Log(string.Format(DISPLAYING_FORMAT, coinComponent.ValueRO.Balance));
    }
}