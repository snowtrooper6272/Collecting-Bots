using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private PoolFactory _poolFactory;
    [SerializeField] private SpawnArea[] _areas;

    private Coroutine _spawning;

    private void Start()
    {
        _spawning = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawning);
    }

    private IEnumerator Spawning() 
    {
        bool isNeedSpawning = true;
        WaitForSeconds delay = new WaitForSeconds(_interval);

        while (isNeedSpawning) 
        {
            Resource resource = _poolFactory.Spawn();

            if (resource != null)
            {
                resource.Realese(_areas[Random.Range(0, _areas.Length)].GetSpawnPoint());

            }
            
            yield return delay;
        }
    }
}
