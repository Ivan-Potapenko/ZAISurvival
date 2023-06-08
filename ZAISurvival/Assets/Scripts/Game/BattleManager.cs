using UI;
using UnityEngine;

namespace Game {

    public class BattleManager : MonoBehaviour {

        [SerializeField]
        private ZombieWaveController _zombieWaveController;

        [SerializeField]
        private PlayerSpawner _playerSpawner;

        [SerializeField]
        private UIManager _uiManager;

        private void Start() {
            Init();
        }

        private void Init() {
            _playerSpawner.Spawn(_uiManager);
            _uiManager.ActivateScreen(ScreenType.Battle, new InterfaceScreenData { humanoid = _playerSpawner.Player.Humanoid });
          //  _zombieWaveController.Spawn(_playerSpawner.Player);
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.K)) {
                _zombieWaveController.Spawn(_playerSpawner.Player);
            }
        }

    }
}
