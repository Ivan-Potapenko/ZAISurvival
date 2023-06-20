using UnityEngine;

namespace Game {

    public class Explosion : MonoBehaviour {

        [SerializeField]
        private Damage _damage;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
                damageable.TryDoDamage(_damage);
            }
        }

    }
}

