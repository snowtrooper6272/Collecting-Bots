using System.Collections.Generic;
using UnityEngine;

public class PoolFactory : MonoBehaviour
{
    [SerializeField] private Resource[] _prefabs;

    private List<Pool<Resource>> _pools = new List<Pool<Resource>>(0);

    private void OnEnable()
    {
        foreach (var prefab in _prefabs) 
        {
            Pool<Resource> _pool = new Pool<Resource>();

            _pool.Init(prefab);
            _pools.Add(_pool);
        }
    }

    private void OnDisable()
    {
        foreach (var pool in _pools)
        {
            foreach (var content in pool.GetReleasedStorage())
            {
                content.Stored -= Storing;
            }
        }
    }

    public Resource Spawn()
    {
        Pool<Resource> pool = GetSpawnPool();

        Resource spawnResource = pool.Release();

        if (spawnResource != null)
            spawnResource.Stored += Storing;

        return spawnResource;
    }

    private Pool<Resource> GetSpawnPool() 
    {
        Pool<Resource> spawnPool = null;
        int generalChance = 0;
        int droppedChance = 0;
        int poolChances = 0;

        foreach (var pool in _pools) 
        {
            generalChance += pool.Content.Config.Chance;
        }

        droppedChance = Random.Range(0, generalChance);

        foreach (var pool in _pools) 
        {
            poolChances += pool.Content.Config.Chance;

            if (poolChances >= droppedChance)
            {
                spawnPool = pool;
                return spawnPool;
            }
        }

        return spawnPool;
    }

    private void Storing(Resource storedResource)
    {
        storedResource.Stored -= Storing;

        foreach (var pool in _pools) 
        {
            if (pool.IsRealeseResource(storedResource))
                pool.Storing(storedResource);
        }
    }
}
