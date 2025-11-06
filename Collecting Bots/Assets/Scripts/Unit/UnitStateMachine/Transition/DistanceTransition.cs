using UnitStateMachine.States;
using UnitStateMachine.Transitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStateMachine.Transitions
{
    public class DistanceTransition : Transition
    {
        private DistanceChecker _checker;
        private Vector3 _target;
        private float _distance;

        public DistanceTransition(State nextState, DistanceChecker checker, Vector3 target, float distance) : base(nextState)
        {
            _checker = checker;
            _target = target;
            _distance = distance;
        }

        public override bool IsNeedTransit()
        {
            if (_checker.IsLocatedInside(_target, _distance))
                return true;

            return false;
        }
    }
}
