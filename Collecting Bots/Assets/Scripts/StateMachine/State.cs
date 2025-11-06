using UnitStateMachine.Transitions;
using System;
using System.Collections.Generic;

namespace UnitStateMachine.States
{
    public abstract class State
    {
        protected List<Transition> _transitions = new();
        
        protected Unit TrackedUnit;

        public event Action<State> Changed;

        public State(List<Transition> transitions, Unit unit)
        {
            _transitions = transitions;
            TrackedUnit = unit;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public void Update()
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.IsNeedTransit())
                {
                    Changed.Invoke(transition.NextState);

                    break;
                }
            }
        }

        public virtual void OnUpdate()
        {
        }
    }
}