using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class BattleManager : MonoBehaviour {

        [SerializeField]
        private ZombieWaveController _zombieWaveController;

        [SerializeField]
        private PlayerSpawner _playerSpawner;

        private void Awake() {
            Init();
        }

        private void Init() {
            _playerSpawner.Spawn();
        }

    }
}
