using UnityEngine;

namespace Game {

    public class ZombieTrapDestroyLogic : ZombieLogic {

        private void OnCollisionEnter(Collision collision) {
            if (_humanoid.destroyableByZombies == null && collision.gameObject.TryGetComponent<DestroyableByZombies>(out var destroyable)
                && destroyable.Type == DestroyableByZombies.DestroyableByZombiesType.Contact) {
                _humanoid.destroyableByZombies = destroyable;
            }
        }

        private void OnCollisionExit(Collision collision) {
            if (_humanoid.destroyableByZombies != null && _humanoid.destroyableByZombies.Type == DestroyableByZombies.DestroyableByZombiesType.Contact
                && collision.gameObject.TryGetComponent<DestroyableByZombies>(out var destroyable) && destroyable == _humanoid.destroyableByZombies) {
                _humanoid.destroyableByZombies = null;
            }
        }

        public override void HandleInput(HumanoidInput playerInput) {
            if(_humanoid.destroyableByZombies != null) {
                _humanoid.destroyableByZombies.Destroy(Time.deltaTime);
            }
        }

        public override void OnUpdate() {
        }
    }
}

