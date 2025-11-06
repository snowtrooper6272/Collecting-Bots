using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitStateMachine.Transitions;

namespace UnitStateMachine.States
{
    public class MoveState : State
    {
        private Vector3 _target;

        public MoveState(List<Transition> transitions, Unit unit, Vector3 target) : base(transitions, unit) 
        {
            _target = target;
        }

        public override void Enter()
        {
            TrackedUnit.StartMove(_target);
        }
    }
}