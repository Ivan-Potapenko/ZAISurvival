
using System;
using UnityEngine.PlayerLoop;

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

        bool TryDoDamage(Damage damage);

        void Init(Health health);
    }
}
