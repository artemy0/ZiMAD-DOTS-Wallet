using Unity.Collections;
using Unity.Entities;

[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public partial struct ClearCoinTagSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    public void OnUpdate(ref SystemState state)
    {
        var wallet = SystemAPI.GetSingletonEntity<WalletAspect>();
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        ecb.RemoveComponent<AddCoinTag>(wallet);
        ecb.RemoveComponent<RemoveCoinTag>(wallet);

        ecb.Playback(state.EntityManager);
    }
}