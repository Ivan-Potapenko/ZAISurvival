using Data;
using UnityEngine;

namespace Game {

    public class ZombieWaveController : MonoBehaviour {

        [SerializeField]
        private ZombieWavesData _zombieWaveData;

        [SerializeField]
        private ZombieSpawner _spawner;

        public void Spawn(PlayerLogicController player) {
            _spawner.Spawn(player);
        }
    }
}
