using System;
using UnityEngine;

namespace Game {

    public class HumanoidController {

        [Serializable]
        public class HumanoidControllerSettings {

            [SerializeField]
            private float _standingHeight;
            public float StandingHeight => _standingHeight;

            [SerializeField]
            private float _crouchHeight;
            public float CrouchHeight => _crouchHeight;

            [SerializeField]
            private float _hieghtChangeSpeed;
            public float HieghtChangeSpeed => _hieghtChangeSpeed;
        }

        private CharacterController _characterController;

        private PointOfView _pointOfView;

        private Vector3 _moveVector;

        private float _moveTime;
        private Vector2 _currentMoveDirection;

        public bool _isGrounded => _characterController.isGrounded;

        private CapsuleCollider _collider;

        private HumanoidControllerSettings _settings;
        private bool _isCrouch = false;

        public HumanoidController(CharacterController characterController, PointOfView pointOfView, HumanoidControllerSettings humanoidControllerSettings, CapsuleCollider collider) {
            _characterController = characterController;
            _pointOfView = pointOfView;
            _settings = humanoidControllerSettings;
            _collider = collider;
        }

        public void OnUpdate(float gravity) {
            UpdateHeight();
            _moveVector.y -= gravity * Time.deltaTime;
            _characterController.Move(_moveVector);
        }

        private void UpdateHeight() {
            var targetHeight = _isCrouch && _isGrounded ? _settings.CrouchHeight : _settings.StandingHeight;
            var step = _settings.HieghtChangeSpeed * Time.deltaTime;
            _characterController.height = Mathf.Lerp(_characterController.height, targetHeight, step);
            _collider.height = _characterController.height;
            if (_isCrouch && _isGrounded) {
                _moveVector.y -= step;
            }
        }

        public void Rotate(Vector2 mouseDelta, float rotationSpeed, float minYRotate, float maxYRotate) {
            mouseDelta *= rotationSpeed * Time.deltaTime;
            var rotationVector = new Vector3(Mathf.Clamp(-mouseDelta.y + _pointOfView.transform.localRotation.eulerAngles.x, minYRotate, maxYRotate),
                mouseDelta.x + _characterController.transform.rotation.eulerAngles.y, 0);
            _characterController.transform.rotation = Quaternion.Euler(0, rotationVector.y, 0);
            _pointOfView.transform.localRotation = Quaternion.Euler(rotationVector.x, 0, 0);
        }

        public void ForceRotate(Vector2 mouseDelta, float minYRotate, float maxYRotate) {
            var rotationVector = new Vector3(Mathf.Clamp(-mouseDelta.y + _pointOfView.transform.localRotation.eulerAngles.x, minYRotate, maxYRotate),
                mouseDelta.x + _characterController.transform.rotation.eulerAngles.y, 0);
            _characterController.transform.rotation = Quaternion.Euler(0, rotationVector.y, 0);
            _pointOfView.transform.localRotation = Quaternion.Euler(rotationVector.x, 0, 0);
        }

        public void Move(Vector2 direction, float speed, AnimationCurve moveAccelerationCurve, float timeToMaxSpeed) {
            if (_currentMoveDirection == Vector2.zero || Vector2.Angle(_currentMoveDirection, direction) > 90 && direction != Vector2.zero) {
                _moveTime = 0;
            }
            if (direction == Vector2.zero) {
                if (_moveTime <= 0) {
                    _currentMoveDirection = Vector2.zero;
                } else {
                    _moveTime -= Time.deltaTime;
                    direction = _currentMoveDirection;
                }
            } else {
                _currentMoveDirection = direction;
                if (_moveTime < timeToMaxSpeed) {
                    _moveTime += Time.deltaTime;
                }
            }
            Vector3 forward = _characterController.transform.TransformDirection(Vector3.forward);
            Vector3 right = _characterController.transform.TransformDirection(Vector3.right);
            var directionVector = forward * direction.y + right * direction.x;
            directionVector *= Time.deltaTime * speed * moveAccelerationCurve.Evaluate(_moveTime / timeToMaxSpeed);
            _moveVector.x = directionVector.x;
            _moveVector.z = directionVector.z;
        }

        public void Jump(float force) {
            if (!_characterController.isGrounded) {
                return;
            }
            _moveVector.y = force;
        }

        public void SitDown() {
            _isCrouch = true;
        }

        public void StandUp() {
            _isCrouch = false;
        }
    }
}