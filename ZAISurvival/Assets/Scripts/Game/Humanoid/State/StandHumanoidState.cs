using Data;
using System;
using UnityEngine;

namespace Game {

    public class StandHumanoidState : HumanoidState {
        public StandHumanoidState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) : base(controller, stateData, switchStateCallback) {
        }

        public override void Move(Vector3 direction) {
            if(direction != Vector3.zero) {
                SwitchState(Humanoid.StateType.Walk).Move(direction);
                return;
            }
            _controller.Move(direction, _currentSpeed, StateData.MoveAccelerationCurve, StateData.TimeToMaxSpeed);
        }
    }
}
