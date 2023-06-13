using UnityEngine;

namespace Game {

    public class DamageableHumanoid : MonoBehaviour, IDamageable {

        private Health _health;
        public Health Health => _health;

        private GameObject _damageEffect;
        public GameObject DamageEffect => _damageEffect;

        public bool Destroyed { get; set; }

        private bool _canTakeDamage = true;

        public void Init(Health health, GameObject damageEffect) {
            _health = health;
            _damageEffect = damageEffect;
            Destroyed = false;
        }

        public bool TryDoDamage(Damage damage) {
            if(!_canTakeDamage || _health == null) {
                return false;
            }
            _health.ReduceHealth(damage);
            return true;
        }
    }
}

