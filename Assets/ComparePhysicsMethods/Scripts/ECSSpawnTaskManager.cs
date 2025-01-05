using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ECSSpawnTaskManager : MonoBehaviour
{
    public class ECSSpawnProperties
    {
        public int NumberOfObjects;
        public float Grid;
        public int Height;

        public ECSSpawnProperties(int numberOfObjects, float grid, int height)
        {
            NumberOfObjects = numberOfObjects;
            Grid = grid;
            Height = height;
        }
    }
    private List<ECSSpawnProperties> _tasks = new List<ECSSpawnProperties>();
    private List<ECSSpawnProperties> _brustTasks = new List<ECSSpawnProperties>();


    public void Spawn(int numberOfObjects, float grid, int height)
    {
        if (numberOfObjects <= 1)
        {
            return;
        }
        _tasks.Add(new ECSSpawnProperties(numberOfObjects, grid, height));
    }

    public void SpawnBrust(int numberOfObjects, float grid, int height)
    {
        if (numberOfObjects <= 1)
        {
            return;
        }
        _brustTasks.Add(new ECSSpawnProperties(numberOfObjects, grid, height));
    }

    public ECSSpawnProperties GetTask()
    {
        if(_tasks.Count > 0)
        {
            ECSSpawnProperties ret = _tasks[0];
            _tasks.RemoveAt(0);
            return ret; 
        }
        return null; 
    }

    public ECSSpawnProperties GetBrustTask()
    {
        if (_brustTasks.Count > 0)
        {
            ECSSpawnProperties ret = _brustTasks[0];
            _brustTasks.RemoveAt(0);
            return ret;
        }
        return null;
    }

    public static ECSSpawnTaskManager Instance()
    {
        if(_instance == null)
        {
            _instance = FindAnyObjectByType<ECSSpawnTaskManager>();
        }
        return _instance;
    }

    private static ECSSpawnTaskManager _instance = null; 
}
