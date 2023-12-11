using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial struct AddCoinTagSystem : ISystem
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                walletAspect.CoinBalance++;
                ecb.AddComponent<AddCoinTag>(walletAspect.Entity);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                walletAspect.CoinBalance--;
                ecb.AddComponent<RemoveCoinTag>(walletAspect.Entity);
            }
        }
        
        ecb.Playback(state.EntityManager);
    }
}