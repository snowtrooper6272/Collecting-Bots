using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _target;
    private Coroutine _moving;
    private bool _isStartMove = false;

    public event Action Achieved;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isStartMove && transform.position == _target)
        {
            _isStartMove = false;
            Achieved?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if(_isStartMove)
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void StartMove(Vector3 target)
    {
        _target = target;
        _isStartMove = true;
    }
}
