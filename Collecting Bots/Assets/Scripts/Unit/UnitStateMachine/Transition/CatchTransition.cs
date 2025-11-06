using UnitStateMachine.Transitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitStateMachine.States;

namespace UnitStateMachine.Transitions
{
    public class CatchTransition : Transition
    {
        private Unit _unit;
        private bool _isTaked = false;

        public CatchTransition(State nextState, Unit unit) : base(nextState) 
        {
            _unit = unit;
            _unit.Taked += Take;
        }

        private void Take() 
        {
            _isTaked = true;
        }

        public override bool IsNeedTransit()
        {
            return _isTaked;
        }
    }
}
