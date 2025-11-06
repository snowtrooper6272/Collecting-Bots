using System;
using System.Collections;
using System.Collections.Generic;
using UnitStateMachine.States;
using UnitStateMachine.Transitions;
using UnityEngine;

public class FindState : State
{
    private Finder _finder;

    public FindState(List<Transition> transitions, Unit unit, Finder finder) : base(transitions, unit) 
    {
        _finder = finder;
    }

    public override void Enter()
    {
        _finder.Found += TrackedUnit.SetTarget;
        _finder.StartFind();
    }

    public override void Exit()
    {
        _finder.StopFind();
        _finder.Found -= TrackedUnit.SetTarget;
    }
}