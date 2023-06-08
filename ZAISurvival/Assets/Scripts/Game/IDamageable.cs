using System;
using UnityEngine;

namespace Game {

    public enum DamageType {
        PenetratingBullets,
        StabbingTrap,
    }

    [Serializable]
    public struct Damage {
        public float damage;
        public DamageType damageType;
    }

    public interface IDamageable {

        Health Health { get; }

        bool Destroyed { get; set; }

        public GameObject DamageEffect { get; }

        bool TryDoDamage(Damage damage);

        void Init(Health health, GameObject DamageEffect);
    }
}
