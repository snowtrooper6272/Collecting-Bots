using UnitStateMachine.States;
using System;

namespace UnitStateMachine.Transitions
{
    public abstract class Transition
    {
        public State NextState { get; private set; }

        public Transition(State targetState)
        {
            NextState = targetState;
        }

        public abstract bool IsNeedTransit();
    }
}
