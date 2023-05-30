using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class HumanoidCollisionLogic : HumanoidLogic {

        private List<ICollisionDetecter> _currentCollisionObjects = new List<ICollisionDetecter>();
        private List<ICollisionDetecter> _previousCollisionObjects = new List<ICollisionDetecter>();

        public override void HandleInput(HumanoidInput playerInput) {
        }

        public override void OnUpdate() {

            foreach (var detecter in _previousCollisionObjects) {
                if (_previousCollisionObjects.Contains(detecter)) {
                    detecter.OnHumanoidStay(gameObject);
                }
            }
            _previousCollisionObjects = _currentCollisionObjects;
            _currentCollisionObjects = new List<ICollisionDetecter>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit) {
            if (hit.gameObject.TryGetComponent<ICollisionDetecter>(out var collisionDetecter)) {
                if (!_previousCollisionObjects.Contains(collisionDetecter)) {
                    collisionDetecter.OnHumanoidEnter(gameObject);
                }
                _currentCollisionObjects.Add(collisionDetecter);
            }
        }
    }
}

