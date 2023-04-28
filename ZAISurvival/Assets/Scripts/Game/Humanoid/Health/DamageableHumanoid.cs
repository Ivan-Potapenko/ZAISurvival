using UnityEngine;

namespace Game {

    public class DamageableHumanoid : MonoBehaviour, IDamageable {

        private Health _health;
        public Health Health => _health;

        private bool _canTakeDamage;

        public void Init(Health health) {
            _health = health;
        }

        public bool TryDoDamage(Damage damage) {
            if(!_canTakeDamage) {
                return false;
            }
            _health.ReduceHealth(damage);
            return true;
        }
    }
}

