using UI;
using UnityEngine;

namespace Game {

    public class ZombieAIController : MonoBehaviour {

        private PlayerLogicController _humanoidLogicController;

        private bool _inited = false;
        private HumanoidInput _currentInput;

        private ZombieLogicController _zombieLogicController;

        public void Init(PlayerLogicController player, ZombieLogicController zombieLogicController) {
            _humanoidLogicController = player;
            _zombieLogicController = zombieLogicController;
            _inited = true;
        }

        public void Update() {
            if(!_inited) {
                return;
            }
            _currentInput.moveDirection = _humanoidLogicController.transform.position;
            _currentInput.target = _humanoidLogicController.gameObject;
            _currentInput.makeDamageToObject = true;
            _zombieLogicController.HandleInput(_currentInput);
        }
    }
}
