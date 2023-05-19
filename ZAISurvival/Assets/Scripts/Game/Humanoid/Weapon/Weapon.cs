using Data;
using System;
using UnityEngine;

namespace Game {

    [Serializable]
    public struct WeaponUIData {
        public Sprite icon;
        [NonSerialized]
        public int loadedCartridges;
        [NonSerialized]
        public int clipSize;
        [NonSerialized]
        public float spread;
        [NonSerialized]
        public SightType sightType;
        [NonSerialized]
        public bool inReload;
    }

    public abstract class Weapon : MonoBehaviour {

        public enum WeaponType {
            Melee,
            Range
        }

        [SerializeField]
        protected WeaponUIData _weaponUIData;

        [SerializeField]
        protected Vector3 _weaponPositionOffset;

        [SerializeField]
        private Vector3 _aimPositionOffset;

        public bool isAim;

        public abstract WeaponType Type { get; }

        protected Humanoid _humanoid;

        public virtual void Init(Humanoid humanoid) {
            _humanoid = humanoid;
            UpdatePosition();
        }

        public abstract void StartAttacking();

        public abstract void StopAttacking();

        protected abstract bool TryToMakeAttack();

        public virtual void OnUpdate() {
            UpdatePosition();
        }

        protected virtual void UpdatePosition() {
            if(isAim) {
                UpdateAimPosition();
            }
            else {
                gameObject.transform.localPosition = _weaponPositionOffset;
            }
        }

        protected virtual void UpdateAimPosition() {
            gameObject.transform.localPosition = _aimPositionOffset;
        }

        public virtual void SetActive(bool enable) {
            gameObject.SetActive(enable);
            UpdatePosition();
        }

        public virtual void Reload() { }

        public abstract WeaponUIData GetWeaponUIData();

        public virtual Vector2 GetCameraOffset() {
            return Vector2.zero;
        }
    }

}