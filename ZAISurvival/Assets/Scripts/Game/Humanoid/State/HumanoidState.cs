using Data;
using UnityEngine;

namespace Game {

    public abstract class HumanoidState {

        protected HumanoidController _controller;
        public HumanoidController HumanoidController => _controller;

        protected HumanoidStateData _stateData;
        public HumanoidStateData StateData => _stateData;

        protected virtual Vector3 ViewPoint => Vector3.zero;

        public bool isAim;

        public HumanoidState(HumanoidController controller, HumanoidStateData stateData) {
            _controller = controller;
            _stateData = stateData;
        }

        public virtual void Move(Vector2 direction) {
            _controller.Move(direction, isAim ? StateData.AimSpeed : StateData.Speed, StateData.MoveAccelerationCurve, StateData.TimeToMaxSpeed);
        }

        public virtual void Run() { }

        public virtual void Jump() {
            _controller.Jump(_stateData.JumpForce);
        }

        public virtual void Rotate(Vector2 mouseDelta) {
            HumanoidController.Rotate(mouseDelta, _stateData.RotationSpeed, _stateData.MinYRotate, _stateData.MaxYRotate);
        }

        public virtual void ForceRotate(Vector2 mouseDelta) {
            HumanoidController.ForceRotate(mouseDelta, _stateData.MinYRotate, _stateData.MaxYRotate);
        }

        public virtual void UpdateAirYPosition() {
            _controller.UpdateAirYPosition(StateData.Gravity);
        }
    }
}
