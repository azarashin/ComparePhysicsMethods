using Unity.Entities;
using Unity.Mathematics;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public float3 SpawnPositionOrigin;
    public bool Enable; 
}
