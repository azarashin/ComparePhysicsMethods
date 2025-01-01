using Unity.Collections;
using UnityEngine;

/// <summary>
/// see: Unity の物理エンジン最新機能を紹介！ 2022.2 Physics アップデート
/// https://www.youtube.com/watch?v=FtYtM3q-pEY&t=328s
/// </summary>

public class ComtactCollisionEnter : MonoBehaviour
{
    [SerializeField]
    float _delay = 1.0f;

    private void OnEnable()
    {
        Physics.ContactEvent += ContactCallback;
    }

    private void OnDisable()
    {
        Physics.ContactEvent -= ContactCallback;
    }


    void ContactCallback(PhysicsScene scene, NativeArray<ContactPairHeader>.ReadOnly headers)
    {
        int count = 0; 
        foreach (ContactPairHeader header in headers)
        {
            for (int i = 0; i < header.pairCount; i++)
            {
                var contactPair = header.GetContactPair(i);
                if (contactPair.collider.gameObject)
                {
                    Destroy(contactPair.collider.gameObject, _delay);
                }
                count++; 
            }
        }
        Debug.Log($"ComtactCollisionEnter.ContactCallback: count({count})");
    }
}
