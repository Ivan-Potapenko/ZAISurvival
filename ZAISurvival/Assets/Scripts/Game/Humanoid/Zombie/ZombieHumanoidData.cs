using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "ZombieHumanoidData", menuName = "Data/Zombie/ZombieHumanoidData")]
    public class ZombieHumanoidData : HumanoidData {

        [SerializeField]
        private float _attackDistance;
        public float AttackDistance => _attackDistance;
    }
}

