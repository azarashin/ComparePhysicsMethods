using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using Unity.Collections;

[BurstCompile]
public partial struct SpawnerBrustSystem : ISystem
{

    public void OnCreate(ref SystemState state) 
    {
    }

    public void OnDestroy(ref SystemState state) 
    {
    }


    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        ECSSpawnTaskManager manager = ECSSpawnTaskManager.Instance();
        if(manager == null)
        {
            return; 
        }
        ECSSpawnTaskManager.ECSSpawnProperties task = manager.GetBrustTask();
        if(task == null)
        {
            return; 
        }
        foreach (RefRW<ECSSpawner> spawner in SystemAPI.Query<RefRW<ECSSpawner>>())
        {
            ProcessSpawner(ref state, spawner, task);
        }
    }

    [BurstCompile]
    private void ProcessSpawner(ref SystemState state, RefRW<ECSSpawner> spawner, ECSSpawnTaskManager.ECSSpawnProperties task)
    {
        for (int i = 0; i < task.NumberOfObjects; i++)
        {
            int width = (int)math.sqrt(task.NumberOfObjects);
            int x = i % width;
            int y = i / width;
            Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
            // LocalPosition.FromPositionは、指定された位置で初期化されたTransformを返します。
            state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(new float3(x * task.Grid, task.Height, y * task.Grid)));
        }


    }
}