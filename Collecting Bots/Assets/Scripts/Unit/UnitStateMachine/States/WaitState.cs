using UnitStateMachine.Transitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStateMachine.States
{
    public class WaitState : State
    {
        public WaitState(List<Transition> transitions, Unit unit) : base(transitions, unit) { }

        public override void Enter()
        {
            if (TrackedUnit.Target != null)
            {
                TrackedUnit.Storing();
            }
        }
    }
}