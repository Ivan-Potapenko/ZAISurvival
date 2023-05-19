using Game;
using System;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "HumanoidStateData", menuName = "Data/HumanoidStateData")]
    public class HumanoidStateData : ScriptableObject {

        [SerializeField]
        private Humanoid.StateType _stateType;
        public Humanoid.StateType StateType => _stateType;

        [SerializeField]
        private float _weaponSpreadModificator;
        public float WeaponSpreadModificator => _weaponSpreadModificator;

        [SerializeField]
        private float _speed;
        public float Speed => _speed;

        [SerializeField]
        private float _jumpForce;
        public float JumpForce => _jumpForce;

        [SerializeField]
        private float _gravity;
        public float Gravity => _gravity;

        [SerializeField]
        private float _maxYRotate;
        public float MaxYRotate => _maxYRotate;
        [SerializeField]
        private float _minYRotate;
        public float MinYRotate => _minYRotate;
        [SerializeField]
        private float _rotationSpeed;
        public float RotationSpeed => _rotationSpeed;

        [SerializeField]
        private AnimationCurve _moveAccelerationCurve;
        public AnimationCurve MoveAccelerationCurve => _moveAccelerationCurve;

        [SerializeField]
        private float _timeToMaxSpeed;
        public float TimeToMaxSpeed => _timeToMaxSpeed;

        [SerializeField]
        private float _aimSpeed;
        public float AimSpeed => _aimSpeed;
    }
}
