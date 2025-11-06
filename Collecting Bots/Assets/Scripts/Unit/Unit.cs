using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitStateMachine;
using UnitStateMachine.Factory;

public class Unit : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private UnitStateMachineFactory _stateMachineFactory;
    [SerializeField] private Transform _binding;

    private StateMachine _stateMachine;

    public event Action Taked;
    public event Action<Resource> Stored;
    public Resource Target { get; private set; }
    public Vector3 CargoPosition { get; private set; }
    public Vector3 DeliveryPoint { get; private set; }
    public bool IsAct { get; private set; }

    private void Update()
    {
        if (_stateMachine != null)
            _stateMachine.Update();
    }

    public void StartLoot(Vector3 cargoPosition, Vector3 deliveryPoint)
    {
        CargoPosition = cargoPosition;
        DeliveryPoint = deliveryPoint;
        IsAct = true;
        _stateMachine = _stateMachineFactory.Create();
    }

    public void StartMove(Vector3 target)
    {
        _mover.StartMove(target);
    }

    public void Storing()
    {
        Target.DeliveryEnd();
        Stored.Invoke(Target);
        IsAct = false;
        Target = null;
        _stateMachine = null;
    }

    public void DownloadCargo() 
    {
        Target.DeliveryStart(transform, _binding.position);
        Taked.Invoke();
    }

    public void SetTarget(Resource target) 
    {
        Target = target;
    }
}
