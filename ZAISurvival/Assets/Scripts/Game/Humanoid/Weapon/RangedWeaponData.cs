using Unity.VisualScripting;
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

        [SerializeField]
        private float _spreadIncreasSpeed = 1;
        public float SpreadIncreasSpeed => _spreadIncreasSpeed;

        [SerializeField]
        private float _spreadReductionSpeed = 1;
        public float SpreadReductionSpeed => _spreadReductionSpeed;

        [SerializeField]
        private int _bulletsInOneShot = 1;
        public int BulletsInOneShot => _bulletsInOneShot;

        [SerializeField]
        private float _reloadTime = 0;
        public float ReloadTime => _reloadTime;

        [SerializeField]
        private int _bulletsLoadedAtTime;
        public int BulletsLoadedAtTime => _bulletsLoadedAtTime;
    }
}