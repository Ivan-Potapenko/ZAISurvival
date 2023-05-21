using Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "HumanoidStateData", menuName = "Data/HumanoidStateData")]
    public class HumanoidStateData : ScriptableObject {

        [SerializeField]
        private Humanoid.StateType _stateType;
        public Humanoid.StateType StateType => _stateType;

        [BoxGroup("Weapon")]
        [SerializeField]
        private float _weaponSpreadModificator;
        public float WeaponSpreadModificator => _weaponSpreadModificator;

        [BoxGroup("Weapon")]
        [SerializeField]
        private float _inAirWeaponSpreadModificator;
        public float InAirWeaponSpreadModificator => _inAirWeaponSpreadModificator;

        [BoxGroup("Move")]
        [SerializeField]
        private float _speed;
        public float Speed => _speed;

        [BoxGroup("Move")]
        [SerializeField]
        private float _jumpForce;
        public float JumpForce => _jumpForce;

        [BoxGroup("Move")]
        [SerializeField]
        private float _gravity;
        public float Gravity => _gravity;

        [BoxGroup("Rotation")]
        [SerializeField]
        private float _maxYRotate;
        public float MaxYRotate => _maxYRotate;

        [BoxGroup("Rotation")]
        [SerializeField]
        private float _minYRotate;
        public float MinYRotate => _minYRotate;

        [BoxGroup("Rotation")]
        [SerializeField]
        private float _rotationSpeed;
        public float RotationSpeed => _rotationSpeed;

        [BoxGroup("Move")]
        [SerializeField]
        private AnimationCurve _moveAccelerationCurve;
        public AnimationCurve MoveAccelerationCurve => _moveAccelerationCurve;

        [BoxGroup("Move")]
        [SerializeField]
        private float _timeToMaxSpeed;
        public float TimeToMaxSpeed => _timeToMaxSpeed;

        [BoxGroup("Move")]
        [SerializeField]
        private float _inAimMoveSpeed;
        public float InAimMoveSpeed => _inAimMoveSpeed;
    }
}
