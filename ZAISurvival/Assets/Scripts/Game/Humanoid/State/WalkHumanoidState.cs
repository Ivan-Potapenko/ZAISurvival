using Data;
using System;
using UnityEngine;

namespace Game {
    public class WalkHumanoidState : HumanoidState {
        public WalkHumanoidState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) 
            : base(controller, stateData, switchStateCallback) {
        }

        public override void Move(Vector2 direction) {
            if (direction == Vector2.zero) {
                SwitchState(Humanoid.StateType.Stand)?.Move(direction);
                return;
            }
            _controller.Move(direction, _currentSpeed, StateData.MoveAccelerationCurve, StateData.TimeToMaxSpeed);
        }
    }
}

