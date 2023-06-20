using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class Claymore : Trap {

        [SerializeField]
        private Transform _explosionPoint;

        [SerializeField]
        private Explosion _explosion;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent<HumanoidTrapInteractionLogic>(out var humanoidTrap)) {
                Activate();
            }
        }

        public override void Activate() {
            Instantiate(_explosion, _explosionPoint.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        public override void Deactivate() {
        }
    }
}
