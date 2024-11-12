using Game;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "ZombieHumanoidData", menuName = "Data/Zombie/ZombieHumanoidData")]
    public class ZombieHumanoidData : HumanoidData {

        [SerializeField]
        private float _attackDistance;
        public float AttackDistance => _attackDistance;

        [SerializeField]
        private Damage _damage;
        public Damage Damage => _damage;

        [SerializeField]
        private float _timeBetweenAttack;
        public float TimeBetweenAttack => _timeBetweenAttack;
    }
}

