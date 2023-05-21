using Data;
using System;
using UnityEngine;

namespace Game {

    public abstract class HumanoidState {

        protected HumanoidController _controller;
        public HumanoidController HumanoidController => _controller;

        protected HumanoidStateData _stateData;
        public HumanoidStateData StateData => _stateData;

        private float _inStateTime;

        protected virtual Vector3 ViewPoint => Vector3.zero;

        private bool _isAim;
        public bool IsAim {
            get { return _isAim; }
            set { _isAim = value; }
        }

        protected float _currentSpeed => IsAim && _controller._isGrounded ? _stateData.InAimMoveSpeed : _stateData.Speed;

        public float WeaponSpreadModificator => _controller._isGrounded ? _stateData.WeaponSpreadModificator : _stateData.InAirWeaponSpreadModificator;

        private Func<Humanoid.StateType, HumanoidState> _switchStateCallback;

        public HumanoidState(HumanoidController controller, HumanoidStateData stateData, Func<Humanoid.StateType, HumanoidState> switchStateCallback) {
            _controller = controller;
            _stateData = stateData;
            _switchStateCallback = switchStateCallback;
        }

        public virtual void Activate() {
            _inStateTime = 0;
        }

        public virtual void Deactivate() { }

        public virtual void Move(Vector2 direction) {
            if (direction == Vector2.zero) {
                SwitchState(Humanoid.StateType.Stand)?.Move(direction);
                return;
            }
            SwitchState(Humanoid.StateType.Walk)?.Move(direction);//_controller.Move(direction, IsAim ? StateData.InAimMoveSpeed : StateData.Speed, StateData.MoveAccelerationCurve, StateData.TimeToMaxSpeed);
        }

        public virtual void Run(Vector2 direction) {
            if (direction != Vector2.zero && Math.Abs(Vector2.Angle(direction, Vector2.up)) < 90) {
                SwitchState(Humanoid.StateType.Run)?.Run(direction);
                return;
            }
            Move(direction);
        }

        public virtual void Crouch(Vector2 direction) {
            if (_controller._isGrounded) {
                SwitchState(Humanoid.StateType.Crouch)?.Crouch(direction);
            }
        }

        public virtual void Jump() {
            _controller.Jump(_stateData.JumpForce);
        }

        public virtual void Rotate(Vector2 mouseDelta) {
            HumanoidController.Rotate(mouseDelta, _stateData.RotationSpeed, _stateData.MinYRotate, _stateData.MaxYRotate);
        }

        public virtual void ForceRotate(Vector2 mouseDelta) {
            HumanoidController.ForceRotate(mouseDelta, _stateData.MinYRotate, _stateData.MaxYRotate);
        }

        public virtual void Update() {
            _inStateTime += Time.deltaTime;
            _controller.OnUpdate(StateData.Gravity);
        }

        protected HumanoidState SwitchState(Humanoid.StateType stateType) {
            Deactivate();
            var state = _switchStateCallback.Invoke(stateType);
            state.IsAim = IsAim;
            return state;
        }
    }
}
