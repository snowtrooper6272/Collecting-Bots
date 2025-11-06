using System.Collections;
using System.Collections.Generic;
using UnitStateMachine.States;
using UnitStateMachine.Transitions;
using UnityEngine;

public class MissedTransition : Transition
{
    private Finder _finder;
    private bool _isFinish;

    public MissedTransition(State nextState, Finder finder) : base(nextState)
    {
        _finder = finder;
        _finder.Finished += Transit;
    }

    private void Transit() 
    {
        _isFinish = true;
    }

    public override bool IsNeedTransit()
    {
        return _isFinish;
    }
}
