using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct AddCrystalTagSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var walletAspect in SystemAPI.Query<WalletAspect>())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                walletAspect.CrystalBalance++;
                ecb.AddComponent<AddCrystalTag>(walletAspect.Entity);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                walletAspect.CrystalBalance--;
                ecb.AddComponent<RemoveCrystalTag>(walletAspect.Entity);
            }
        }
        
        ecb.Playback(state.EntityManager);
    }
}