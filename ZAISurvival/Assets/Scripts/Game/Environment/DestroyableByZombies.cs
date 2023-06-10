using UnityEngine;

namespace Game {

    public class DestroyableByZombies : MonoBehaviour {

        public enum DestroyableByZombiesType {
            Contact,
            Controllable,
        }

        [SerializeField]
        private DestroyableByZombiesType _type;
        public DestroyableByZombiesType Type => _type;

        [SerializeField]
        private float health = 100;

        public void Destroy(float damage) {
            health -= damage;
            if(health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
