using System.Collections;
using System.Collections.Generic;
using UnitStateMachine.States;
using UnitStateMachine.Transitions;
using UnityEngine;

public class ReceivedTransition : Transition
{
    private Unit _unit;

    public ReceivedTransition(State nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    public override bool IsNeedTransit()
    {
        if (_unit.Target != null)
            return true;

        return false;
    }
}
