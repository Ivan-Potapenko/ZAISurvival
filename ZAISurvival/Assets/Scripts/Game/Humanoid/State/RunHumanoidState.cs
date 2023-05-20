using Data;
using System;
using UnityEngine;

namespace Game {

    public class RunHumanoidState : HumanoidState {
        public RunHumanoidState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) : base(controller, stateData, switchStateCallback) {
        }

        public override void Run(Vector2 direction) {
            if (direction == Vector2.zero) {
                SwitchState(Humanoid.StateType.Stand)?.Move(direction);
                return;

            }
            if (Math.Abs(Vector2.Angle(direction, Vector2.up)) >= 90) {
                SwitchState(Humanoid.StateType.Walk)?.Move(direction);
                return;
            }
            _controller.Move(direction, StateData.Speed, StateData.MoveAccelerationCurve, StateData.TimeToMaxSpeed);
        }
    }
}
