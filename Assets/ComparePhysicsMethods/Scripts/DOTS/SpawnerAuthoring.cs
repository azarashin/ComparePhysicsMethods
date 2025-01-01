using UnityEngine;
using Unity.Entities;

class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
}

class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        Debug.Log(entity.Index);
        AddComponent(entity, new Spawner
        {
            // �f�t�H���g�ł́A�e�I�[�T�����OGameObject��Entity�ɕϊ�����܂��B
            // GameObject�i�܂��̓I�[�T�����O�R���|�[�l���g�j���^������ƁAGetEntity�͐��������Entity���������܂��B
            Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
            SpawnPositionOrigin = authoring.transform.position,
            Enable = true, 
        });
    }
}
