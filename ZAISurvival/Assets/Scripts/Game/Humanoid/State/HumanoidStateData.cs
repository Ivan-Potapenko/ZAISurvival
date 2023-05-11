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
    }
}
