using UnityEngine;

namespace Game {

    public class DamageContactTrap : Trap, ICollisionDetecter {

        [SerializeField]
        private DestroyAfterTimeParticle _bloodEffect;

        [SerializeField]
        private Damage _damage;

        public void OnHumanoidEnter(GameObject collisionHumanoid) {
            if (collisionHumanoid.TryGetComponent<HumanoidTrapInteractionLogic>(out var humanoidTrapInteractionLogic)) {
                if (humanoidTrapInteractionLogic.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                    damageable.TryDoDamage(_damage);
                    Instantiate(_bloodEffect, collisionHumanoid.transform.position, Quaternion.identity);
                }
            }
        }

        private void OnTriggerEnter(Collider other) {

        }

        private void OnControllerColliderHit(ControllerColliderHit hit) {
            Debug.Log("Hit");
        }

        /* private void OnControllerColliderHit(ControllerColliderHit hit) {
             if (hit.gameObject.TryGetComponent<HumanoidTrapInteractionLogic>(out var humanoidTrapInteractionLogic)) {
                 if (humanoidTrapInteractionLogic.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                     damageable.TryDoDamage(_damage);
                     Instantiate(_bloodEffect, hit.point, Quaternion.identity);
                 }
             }
         }*/

        public override void Activate() {
        }

        public override void Deactivate() {
        }

        public void OnHumanoidExit(GameObject collisionHumanoid) {
        }

        public void OnHumanoidStay(GameObject collisionHumanoid) {
        }
    }
}


