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
        // ���ׂĂ�Spawner�R���|�[�l���g���N�G�����܂��B���̃V�X�e���́A
        // �R���|�[�l���g����ǂݎ��Ə������݂��s���K�v�����邽�߁ARefRW���g�p���܂��B
        // �V�X�e�����ǂݎ���p�̃A�N�Z�X�݂̂�K�v�Ƃ���ꍇ�́ARefRO���g�p���܂��B
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