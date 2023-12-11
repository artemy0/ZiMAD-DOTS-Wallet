using Unity.Entities;
using UnityEngine;

public class WalletMono : MonoBehaviour
{
    // TODO Add initialization parameters.
}

public class WalletBaker : Baker<WalletMono>
{
    public override void Bake(WalletMono authoring)
    {
        AddComponent(new CoinComponent
        {
            Balance = 0
        });
        AddComponent(new CrystalComponent
        {
            Balance = 0
        });
        // TODO Add more currency types.
    }
}