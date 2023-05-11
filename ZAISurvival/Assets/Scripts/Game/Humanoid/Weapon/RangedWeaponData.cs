using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "RangedWeaponData", menuName = "Data/RangedWeaponData")]
    public class RangedWeaponData : WeaponData {

        [SerializeField]
        private AnimationCurve _damageDistanceCurve;
        public AnimationCurve DamageDistanceCurve => _damageDistanceCurve;

        [SerializeField]
        private AnimationCurve _weaponSpreadCurve;
        public AnimationCurve WeaponSpreadCurve => _weaponSpreadCurve;

        [SerializeField]
        private float _minSpread;
        public float MinSpread => _minSpread;

        [SerializeField]
        private float _maxSpread;
        public float MaxSpread => _maxSpread;

        [SerializeField]
        private int _clipSize;
        public int ClipSize => _clipSize;
    }
}