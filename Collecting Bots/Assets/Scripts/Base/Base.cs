using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Unit[] _units;
    [SerializeField] private Scanner _scanner;
    [SerializeField] private DeliveryArea _deliveryArea;
    [SerializeField] private float _scanInterval;
    [SerializeField] private int _resourcesCount;

    private List<Resource> _busyResource = new List<Resource>(0);
    private Coroutine _scanning;

    private void OnEnable()
    {
        foreach (var unit in _units) 
        {
            unit.Stored += GetDeliveryResource;
        }

        _scanning = StartCoroutine(ScanningMap());
    }

    private void OnDisable()
    {
        StopCoroutine(_scanning);
    }

    public IEnumerator ScanningMap()
    {
        WaitForSeconds delay = new WaitForSeconds(_scanInterval);
        bool isNeedScan = true;

        while (isNeedScan) 
        {
            Resource[] findedResources = _scanner.Scan(_busyResource);

            if (findedResources.Length > 0)
            {
                Unit freeUnit = GetFreeUnit();
                Resource target = findedResources[0];

                if (freeUnit != null)
                {
                    freeUnit.StartLoot(target.transform.position, _deliveryArea.transform.position);
                    _busyResource.Add(target);
                }
            
                yield return delay;
            }
            else 
            {
                yield return null;
            }
        }
    }

    private Unit GetFreeUnit()
    {
        foreach (Unit unit in _units) 
        {
            if (unit.IsAct == false)
                return unit;
        }

        return null;
    }

    public void GetDeliveryResource(Resource deliveryResource) 
    {
        _resourcesCount+= deliveryResource.Config.Price;
        _busyResource.Remove(deliveryResource);
    }
}
