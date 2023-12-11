using Unity.Entities;

public struct CrystalComponent : IComponentData
{
    public int Balance;
}

public struct AddCrystalTag : IComponentData
{
    // TODO Add operation value
}

public struct RemoveCrystalTag : IComponentData
{
    // TODO Add operation value
}