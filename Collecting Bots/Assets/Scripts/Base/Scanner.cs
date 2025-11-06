using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    public Resource[] Scan(List<Resource> resourcesFilter)
    {
        List<Resource> findedResources = new List<Resource>(0);
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius, _layer.value);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Resource resource))
            {
                findedResources.Add(resource);
            }
        }

        foreach (var filter in resourcesFilter) 
        {
            for (int i = 0; i < findedResources.Count; i++) 
            {
                if (filter == findedResources[i])
                {
                    findedResources.Remove(findedResources[i]);
                    i--;
                }
            }
        }

        return findedResources.ToArray();
    }
}
