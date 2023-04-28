using UnityEngine;

namespace Game {

    public class PlayerSpawner : MonoBehaviour {

        [SerializeField]
        private SpawnPoint _spawnPoint;

        [SerializeField]
        private HumanoidLogicController _playerPrefab;

        [SerializeField]
        private PlayerInputConroller _playerInputControllerPrefab;

        private HumanoidLogicController _player;
        public HumanoidLogicController Player => _player;

        private PlayerInputConroller _playerInputController;
        public PlayerInputConroller PlayerInputController => _playerInputController;

        public void Spawn() {
            _player = Instantiate(_playerPrefab, _spawnPoint.transform.position, Quaternion.identity);
            _playerInputController = Instantiate(_playerInputControllerPrefab);
            _playerInputController.Init(_player);
        }
    }
}
