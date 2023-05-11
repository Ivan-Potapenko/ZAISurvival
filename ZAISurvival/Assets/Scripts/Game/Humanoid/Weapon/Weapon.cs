using UnityEngine;

namespace Game {

    public abstract class Weapon : MonoBehaviour {

        public enum WeaponType {
            Melee,
            Range
        }

        [SerializeField]
        private Vector3 _weaponPositionOffset;

        public abstract WeaponType Type { get; }

        protected Humanoid _humanoid;

        public virtual void Init(Humanoid humanoid) {
            _humanoid = humanoid;
        }

        public abstract void StartAttacking();

        public abstract void StopAttacking();

        protected abstract bool TryToMakeAttack();

        public virtual void OnUpdate() {
            UpdatePosition();
        }

        protected virtual void UpdatePosition() {
            gameObject.transform.localPosition = _weaponPositionOffset;
        }

        public virtual void SetActive(bool enable) {
            gameObject.SetActive(enable);
        }
    }

}