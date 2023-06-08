using System.Collections.Generic;
using UI;
using UnityEditor;
using UnityEngine;

namespace Game {

    public class ZombieSpawner : MonoBehaviour {

        [SerializeField]
        private List<SpawnPoint> _spawnPoints;

        [SerializeField]
        private ZombieLogicController _zombiePrefab;

       /* [SerializeField]
        private ZombieAIController _zombieInputControllerPrefab;*/

        private PlayerLogicController _player;

        private List<ZombieLogicController> _zombies;
        public List<ZombieLogicController> Zombie => _zombies;

        private ZombieAIController _zombieAIController;
        public ZombieAIController zombieInputController => _zombieAIController;

        public void Spawn(PlayerLogicController player) {
            _player = player;
            _zombies = new List<ZombieLogicController>();
            foreach (var spawnPoint in _spawnPoints) {
                _zombies.Add(Instantiate(_zombiePrefab, spawnPoint.transform.position, Quaternion.identity));
                _zombies[_zombies.Count - 1].GetComponent<ZombieAIController>().Init(player, _zombies[_zombies.Count - 1]);
            }
        }
    }
}

