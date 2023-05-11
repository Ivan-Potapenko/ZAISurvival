using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data {

    public abstract class WeaponData : ScriptableObject {

        [SerializeField]
        private Damage _damage;
        public Damage Damage => _damage;

        [SerializeField]
        private float _secondsBetweenAttacks;
        public float SecondsBetweenAttacks => _secondsBetweenAttacks;

        [SerializeField]
        private bool _isAutomaticWeapon;
        public bool IsAutomaticWeapon => _isAutomaticWeapon;

        [SerializeField]
        private float _attackDistance;
        public float MaxAttackDistance => _attackDistance;
    }
}
