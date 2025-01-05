using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using Unity.Collections;

[BurstCompile]
public partial class SpawnerSystem : SystemBase
{

    public void OnCreate(ref SystemState state) 
    {
    }

    public void OnDestroy(ref SystemState state) 
    {
    }


    protected override void OnUpdate()
    {
        ECSSpawnTaskManager manager = ECSSpawnTaskManager.Instance();
        if(manager == null)
        {
            return; 
        }
        ECSSpawnTaskManager.ECSSpawnProperties task = manager.GetTask();
        if(task == null)
        {
            return; 
        }
        Entities
            .WithStructuralChanges()
            .ForEach((Entity entity, ref ECSSpawner spawner) =>
            {
                ProcessSpawner(spawner, task);
            }).Run();
    }

    private void ProcessSpawner(ECSSpawner spawner, ECSSpawnTaskManager.ECSSpawnProperties task)
    {
        for (int i = 0; i < task.NumberOfObjects; i++)
        {
            int width = (int)math.sqrt(task.NumberOfObjects);
            int x = i % width;
            int y = i / width;
            Entity newEntity = EntityManager.Instantiate(spawner.Prefab);
            EntityManager.SetComponentData(newEntity, LocalTransform.FromPositionRotation(new float3(x * task.Grid, task.Height, y * task.Grid), new quaternion()));
        }


    }
}