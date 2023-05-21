using Game;
using System.Collections.Generic;
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "HumanoidData", menuName = "Data/HumanoidData")]
    public class HumanoidData : ScriptableObject {

        [SerializeField]
        private HealthData _healthData;
        public HealthData HealthData => _healthData;

        [SerializeField]
        private List<HumanoidStateData> _stateDatas;
        public List<HumanoidStateData> StateDatas => _stateDatas;

        [SerializeField]
        private List<Weapon> _weaponPrefabs;
        public List<Weapon> WeaponPrefabs => _weaponPrefabs;

        [SerializeField]
        private LayerMask _enemyLayerMask;
        public LayerMask EnemyLayerMask => _enemyLayerMask;

        [SerializeField]
        private List<ResourceData> _resourceDatas;
        public List<ResourceData> ResourceDatas => _resourceDatas;
    }
}
