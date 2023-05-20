using System;
using UnityEngine;

namespace Data {

    [Serializable]
    public class WeaponAimSettings {
        [SerializeField]
        private AnimationCurve _weaponSpreadCurve;
        public AnimationCurve WeaponSpreadCurve => _weaponSpreadCurve;

        [SerializeField]
        private float _minSpread;
        public float MinSpread => _minSpread;

        [SerializeField]
        private float _maxSpread;
        public float MaxSpread => _maxSpread;
    }

    [CreateAssetMenu(fileName = "RangedWeaponData", menuName = "Data/RangedWeaponData")]
    public class RangedWeaponData : WeaponData {

        [SerializeField]
        private AnimationCurve _damageDistanceCurve;
        public AnimationCurve DamageDistanceCurve => _damageDistanceCurve;

        [SerializeField]
        private WeaponAimSettings _defaultSpreadSettings;
        public WeaponAimSettings DefaultSpreadSettings => _defaultSpreadSettings;

        [SerializeField]
        private WeaponAimSettings _inAimSpreadSettings;
        public WeaponAimSettings InAimSpreadSettings => _inAimSpreadSettings;

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

        [SerializeField]
        private Vector2 _shootCameraOffset;
        public Vector2 ShootCameraOffset => _shootCameraOffset;

        [SerializeField]
        private float _secondsToMaxShootOffset;
        public float SecondsToMaxShootOffset => _secondsToMaxShootOffset;

        [SerializeField]
        private float _spreadUpdateSpeed;
        public float SpreadUpdateSpeed => _spreadUpdateSpeed;
    }
}