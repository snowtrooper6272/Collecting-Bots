using System;
using UnitStateMachine.States;

namespace UnitStateMachine
{
    public class StateMachine
    {
        private State _currentState;

        public StateMachine(State startState)
        {
            _currentState = startState;
            _currentState.Enter();
            _currentState.Changed += ChangeState;
        }

        private void ChangeState(State nextState)
        {
            _currentState.Exit();
            _currentState.Changed -= ChangeState;

            _currentState = nextState;
            _currentState.Enter();
            _currentState.Changed += ChangeState;
        }

        public void Update()
        {
            _currentState.Update();
            _currentState.OnUpdate();
        }
    }
}