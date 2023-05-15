using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace Game {

    public class HumanoidController {

        private CharacterController _characterController;

        private Camera _camera;

        private Vector3 _moveVector;

        public HumanoidController(CharacterController characterController, Camera camera) {
            _characterController = characterController;
            _camera = camera;
        }

        public void UpdateAirYPosition(float gravity) {
            //Vector3 downVector = _characterController.transform.TransformDirection(Vector3.down);
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

        public void Move(Vector2 direction, float speed) {
            Vector3 forward = _characterController.transform.TransformDirection(Vector3.forward);
            Vector3 right = _characterController.transform.TransformDirection(Vector3.right);
            var directionVector = forward * direction.y + right * direction.x;
            directionVector *= Time.deltaTime * speed;
            _moveVector.x = directionVector.x;
            _moveVector.z = directionVector.z;
            //_characterController.Move(directionVector * Time.deltaTime * speed);
        }

        public void Jump(float force) {
            Debug.Log(_characterController.isGrounded+ " " + _characterController.velocity);
            if (!_characterController.isGrounded) {
                return;
            }
            _moveVector.y = force * Time.deltaTime;
        }
    }
}