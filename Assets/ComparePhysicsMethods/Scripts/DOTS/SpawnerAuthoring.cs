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
            // デフォルトでは、各オーサリングGameObjectはEntityに変換されます。
            // GameObject（またはオーサリングコンポーネント）が与えられると、GetEntityは生成されるEntityを検索します。
            Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
            SpawnPositionOrigin = authoring.transform.position,
            Enable = true, 
        });
    }
}
