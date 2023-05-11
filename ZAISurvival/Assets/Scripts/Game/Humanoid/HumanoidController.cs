using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Game {

    public class HumanoidController {

        private CharacterController _characterController;

        private float _maxYRotate;
        private float _minYRotate;

        public HumanoidController(CharacterController characterController, float maxYRotate, float minYRotate) {
            _characterController = characterController;
            _maxYRotate = maxYRotate;
            _minYRotate = minYRotate;
        }

        public void Rotate(Vector2 mouseDelta) {
            var rotationVector = new Vector3(-mouseDelta.y, mouseDelta.x, 0) + _characterController.transform.rotation.eulerAngles;
            if (rotationVector.x < _maxYRotate && rotationVector.x > _minYRotate) {
                rotationVector.x = _characterController.transform.rotation.eulerAngles.x;
            }
            Debug.Log(_characterController.transform.rotation.eulerAngles);
            _characterController.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}