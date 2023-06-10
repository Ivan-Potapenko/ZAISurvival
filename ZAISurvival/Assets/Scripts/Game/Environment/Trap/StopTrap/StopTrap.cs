using UnityEngine;

namespace Game {

    public class StopTrap : Trap {

        [SerializeField]
        private MeshRenderer _trap;

        [SerializeField]
        private MeshRenderer _activeTrap;

        [SerializeField]
        private DestroyAfterTimeParticle _bloodEffect;

        [SerializeField]
        private Damage _damage;

        private HumanoidTrapInteractionLogic _currentTarget;

        private void Start() {
            Deactivate();
        }

        private void OnTriggerEnter(Collider other) {
            if (!IsActive && other.gameObject.TryGetComponent<HumanoidTrapInteractionLogic>(out var humanoidTrapInteractionLogic)) {
                if (other.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                    damageable.TryDoDamage(_damage);
                }
                Activate(humanoidTrapInteractionLogic);
            }
        }

        public void Activate(HumanoidTrapInteractionLogic trapInteractionLogic) {
            if (IsActive) {
                return;
            }
            _currentTarget = trapInteractionLogic;
            _currentTarget.EnterStopTrapState(this);
            Activate();
        }

        public override void Activate() {
            IsActive = true;
            _trap.gameObject.SetActive(false);
            _activeTrap.gameObject.SetActive(true);
            Instantiate(_bloodEffect, gameObject.transform.position, Quaternion.identity);
        }

        public override void Deactivate() {
            if (_currentTarget != null) {
                _currentTarget.ExiteStopTrapState(this);
            }
            IsActive = false;
            _trap.gameObject.SetActive(true);
            _activeTrap.gameObject.SetActive(false);
        }

        private void OnDisable() {
            Deactivate();
        }

        private void OnDestroy() {
            Deactivate();
        }
    }
}

