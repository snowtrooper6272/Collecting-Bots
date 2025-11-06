using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Vector3 GetSpawnPoint() 
    {
        Vector3 generatePosition = new Vector3(Random.Range(transform.position.x - transform.lossyScale.x / 2, transform.position.x + transform.lossyScale.x / 2),
                                               transform.position.y,
                                               Random.Range(transform.position.z - transform.lossyScale.z / 2, transform.position.z + transform.lossyScale.z / 2));
        return generatePosition;
    }
} 