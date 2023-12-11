using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(AddCrystalTagSystem))]
public partial struct DisplayCrystalSystem : ISystem
{
    private const string DISPLAYING_FORMAT = "Crystal.Balance = {0}";
    
    // TODO Inject the dependency on the UI service
    
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
            Debug.Log(string.Format(DISPLAYING_FORMAT, walletAspect.CrystalBalance));
        }
    }
}