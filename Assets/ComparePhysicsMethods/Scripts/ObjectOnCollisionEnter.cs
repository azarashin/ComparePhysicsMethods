using UnityEngine;

public class ObjectOnCollisionEnter : MonoBehaviour
{
    [SerializeField]
    float _delay = 1.0f; 

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject)
        {
            Destroy(gameObject, _delay);
        }
    }

}
