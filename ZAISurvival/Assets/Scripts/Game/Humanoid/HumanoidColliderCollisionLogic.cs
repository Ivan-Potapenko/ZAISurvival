using UnityEngine;

namespace Game {

    public class HumanoidColliderCollisionLogic : HumanoidLogic {

        private void OnCollisionEnter(Collision collision) {
            if(collision.gameObject.TryGetComponent<ICollisionDetecter>(out var collisionDetecter)) {
                collisionDetecter.OnHumanoidEnter(gameObject);
            }
        }

        public override void HandleInput(HumanoidInput playerInput) {
        }

        public override void OnUpdate() {
        }
    }
}
