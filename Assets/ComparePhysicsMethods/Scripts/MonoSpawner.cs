using System.Linq;
using UnityEngine;

public class MonoSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _prefab; 

    private GameObject[] _objectList = null;

    public void Spawn(int numberOfObjects, float grid, int height)
    {
        if(numberOfObjects <= 1)
        {
            return; 
        }

        int width = (int)Mathf.Sqrt(numberOfObjects); 
        _objectList = Enumerable
            .Range(0, numberOfObjects)
            .Select(s => new Vector3((s % width) * grid, height, (s / width) * grid))
            .Select(s => Instantiate(_prefab, s, Quaternion.identity, transform))
            .ToArray();
    }

}
