using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _duration;
    [SerializeField] private LayerMask _layer;

    private float _currentTime;
    private Coroutine _finding;

    public event Action<Resource> Found;
    public event Action Finished;

    private void OnDisable()
    {
        StopFind();
    }

    public void StartFind() 
    {
        _finding = StartCoroutine(Finding());
    }

    public void StopFind() 
    {
        if(_finding != null)
            StopCoroutine(_finding);
    }

    private IEnumerator Finding() 
    {
        _currentTime = 0;

        while (_currentTime < _duration) 
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _radius, _layer.value);

            foreach (var hit in hits) 
            {
                if(hit.TryGetComponent(out Resource resource)) 
                {
                    Found.Invoke(resource);
                }
            }

            yield return null;
        }

        Finished.Invoke();
    }
}
