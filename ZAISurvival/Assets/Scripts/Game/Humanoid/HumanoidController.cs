using UnityEngine;

namespace Game {

    public class HumanoidController {

        private CharacterController _characterController;

        private Camera _camera;

        private Vector3 _moveVector;

        private float _moveTime;
        private Vector2 _currentMoveDirection;

        public HumanoidController(CharacterController characterController, Camera camera) {
            _characterController = characterController;
            _camera = camera;
        }

        public void UpdateAirYPosition(float gravity) {
            _moveVector.y -= gravity * Time.deltaTime;
            _characterController.Move(_moveVector);
        }

        public void Rotate(Vector2 mouseDelta, float rotationSpeed, float minYRotate, float maxYRotate) {
            mouseDelta *= rotationSpeed * Time.deltaTime;
            var rotationVector = new Vector3(Mathf.Clamp(-mouseDelta.y + _camera.transform.localRotation.eulerAngles.x, minYRotate, maxYRotate),
                mouseDelta.x + _characterController.transform.rotation.eulerAngles.y, 0);
            _characterController.transform.rotation = Quaternion.Euler(0, rotationVector.y, 0);
            _camera.transform.localRotation = Quaternion.Euler(rotationVector.x, 0, 0);
        }

        public void ForceRotate(Vector2 mouseDelta, float minYRotate, float maxYRotate) {
            var rotationVector = new Vector3(Mathf.Clamp(-mouseDelta.y + _camera.transform.localRotation.eulerAngles.x, minYRotate, maxYRotate),
                mouseDelta.x + _characterController.transform.rotation.eulerAngles.y, 0);
            _characterController.transform.rotation = Quaternion.Euler(0, rotationVector.y, 0);
            _camera.transform.localRotation = Quaternion.Euler(rotationVector.x, 0, 0);
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
    }
}