
using UnityEngine;

namespace Game {

    public class DamageContactTrap : Trap {

        [SerializeField]
        private DestroyAfterTimeParticle _bloodEffect;

        [SerializeField]
        private Damage _damage;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent<HumanoidTrapInteractionLogic>(out var humanoidTrapInteractionLogic)) {
                if (humanoidTrapInteractionLogic.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                    damageable.TryDoDamage(_damage);
                    Instantiate(_bloodEffect, other.ClosestPointOnBounds(other.gameObject.transform.position)/*.contacts[0].point*/, Quaternion.identity);
                }
            }
        }

       /* private void OnControllerColliderHit(ControllerColliderHit hit) {
            if (hit.gameObject.TryGetComponent<HumanoidTrapInteractionLogic>(out var humanoidTrapInteractionLogic)) {
                if (humanoidTrapInteractionLogic.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                    damageable.TryDoDamage(_damage);
                    Instantiate(_bloodEffect, hit.point, Quaternion.identity);
                }
            }
        }*/

        private void OnCollisionStay(Collision collision) {
            
        }

        private void OnCollisionExit(Collision collision) {
            
        }

        public override void Activate() {
        }

        public override void Deactivate() {
        }
    }
}


