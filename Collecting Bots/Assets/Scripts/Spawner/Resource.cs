using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceConfig _config;

    private Rigidbody _rigidbody;
    private MeshRenderer _renderer;

    public event Action<Resource> Stored;
    public ResourceConfig Config => _config;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();

        _renderer.material.DOColor(Config.Material.color, 0f);
    }

    public void Realese(Vector3 startPosition) 
    {
        transform.position = startPosition;
    }

    public void DeliveryEnd()
    {
        Stored.Invoke(this);
        transform.parent = null;
        _rigidbody.isKinematic = false;
    }

    public void DeliveryStart(Transform binding, Vector3 newBindingPosition)
    {
        transform.SetParent(binding);
        transform.position = newBindingPosition;
        _rigidbody.isKinematic = true;
    }
}
