using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    public const int Max = 14;
    public const float Grid = 2;
    public const float Height = 10;

    public void OnCreate(ref SystemState state) 
    { 
    }

    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        // すべてのSpawnerコンポーネントをクエリします。このシステムは、
        // コンポーネントから読み取りと書き込みを行う必要があるため、RefRWを使用します。
        // システムが読み取り専用のアクセスのみを必要とする場合は、RefROを使用します。
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            ProcessSpawner(ref state, spawner);
        }
    }

    [BurstCompile]
    private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner)
    {
        if(spawner.ValueRO.Enable)
        {
            spawner.ValueRW.Enable = false; 
            for (int i = 0; i < Max; i++)
            {
                int width = (int)math.sqrt(Max);
                int x = i % width;
                int y = i / width;
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(spawner.ValueRO.SpawnPositionOrigin + new float3(x * Grid, Height, y * Grid)));
            }
        }

    }
}