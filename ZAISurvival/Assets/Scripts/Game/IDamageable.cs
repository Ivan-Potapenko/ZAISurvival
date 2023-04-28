
using UnityEngine.PlayerLoop;

namespace Game {

    public enum DamageType {

    }

    public struct Damage {
        public int damage;
        public DamageType damageType;
    }

    public interface IDamageable {

        Health Health { get; }

        bool TryDoDamage(Damage damage);

        void Init(Health health);
    }
}
