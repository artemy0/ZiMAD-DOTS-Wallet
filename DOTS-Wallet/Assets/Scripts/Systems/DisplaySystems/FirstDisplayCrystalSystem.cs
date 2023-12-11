using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
[UpdateAfter(typeof(LoadCrystalSystem))]
public partial struct InitializationDisplayingWalletsCrystalSystem : ISystem
{
    private const string DISPLAYING_FORMAT = "Crystal.Balance = {0}";
    
    // TODO Inject the dependency on the UI service
    
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
        Debug.Log(string.Format(DISPLAYING_FORMAT, crystalComponent.ValueRO.Balance));
    }
}