using UnityEngine;
using System.Collections.Generic;
using UnitStateMachine.Transitions;
using UnitStateMachine.States;

namespace UnitStateMachine.Factory
{
    public class UnitStateMachineFactory : MonoBehaviour
    {
        [SerializeField] private Unit _unit;
        [SerializeField] private Finder _finder;
        [SerializeField] private DistanceChecker _distanceChecker;
        [SerializeField] private DeliveryArea _deliveryArea;

        private float _grabDistanceResource = 1f;
        private float _postingDistanceStorage = 2;

        public StateMachine Create() 
        {
            List<Transition> followTransitions = new List<Transition>(0);
            List<Transition> findTransitions = new List<Transition>(0);
            List<Transition> takeTransitions = new List<Transition>(0);
            List<Transition> deliveryTransitions = new List<Transition>(0);
            List<Transition> waitTransitions = new List<Transition>(0);

            MoveState followState = new MoveState(followTransitions, _unit, _unit.CargoPosition);
            FindState findState = new FindState(findTransitions, _unit, _finder);
            TakeState takeState = new TakeState(takeTransitions, _unit);
            MoveState deliveryState = new MoveState(deliveryTransitions, _unit, _unit.DeliveryPoint);
            WaitState waitState = new WaitState(waitTransitions, _unit);

            followTransitions.Add(new DistanceTransition(findState, _distanceChecker, _unit.CargoPosition, _grabDistanceResource));
            findTransitions.Add(new ReceivedTransition(takeState, _unit));
            findTransitions.Add(new MissedTransition(waitState, _finder));
            takeTransitions.Add(new CatchTransition(deliveryState, _unit));
            deliveryTransitions.Add(new DistanceTransition(waitState, _distanceChecker, _unit.DeliveryPoint, _postingDistanceStorage));

            return new StateMachine(followState);
        }
    }
}
