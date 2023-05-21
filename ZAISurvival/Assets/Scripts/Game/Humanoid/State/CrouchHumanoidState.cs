using Data;
using System;
using UnityEngine;

namespace Game {

    public class CrouchHumanoidState : HumanoidState {
        public CrouchHumanoidState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) : base(controller, stateData, switchStateCallback) {
        }

        public override void Activate() {
            base.Activate();
            if (!_controller._isGrounded) {
                SwitchState(Humanoid.StateType.Walk);
            }
            _controller.SitDown();
        }

        public override void Deactivate() {
            base.Deactivate();
            _controller.StandUp();
        }

        public override void Crouch(Vector2 direction) {
            if(!_controller._isGrounded) {
                SwitchState(Humanoid.StateType.Walk).Move(direction);
            }
            _controller.Move(direction, _currentSpeed, StateData.MoveAccelerationCurve, StateData.TimeToMaxSpeed);
        }

        public override void Jump() {
            SwitchState(Humanoid.StateType.Walk).Jump();
        }

        public override void Update() {
            base.Update();
            if (!_controller._isGrounded) {
                SwitchState(Humanoid.StateType.Walk);
            }
        }
    }
}

