using UnitStateMachine.Transitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitStateMachine.States
{
    public class TakeState : State
    {
        public TakeState(List<Transition> transitions, Unit unit) : base(transitions, unit) { }

        public override void Enter()
        {
            TrackedUnit.DownloadCargo();
        }
    }
}
