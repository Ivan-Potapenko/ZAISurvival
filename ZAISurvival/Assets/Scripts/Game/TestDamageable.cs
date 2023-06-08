using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class TestDamageable : MonoBehaviour, IDamageable {

        private Health _health;

        public Health Health => _health;

        public GameObject DamageEffect => null;

        public bool Destroyed { get ; set; }

        public void Init(Health health, GameObject DamageEffect) {
            Destroyed = false;
        }

        public bool TryDoDamage(Damage damage) {
            Debug.Log($"{gameObject.name} damage type: {damage.damageType}, damage: {damage.damage}");
            return true;
        }
    }

}
