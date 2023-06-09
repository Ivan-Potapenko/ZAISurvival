using Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {

    public class PlayerLogicController : HumanoidLogicController<PlayerHumanoid, PlayerHumanoidData> {

        private List<PlayerHumanoidLogic> _playerHumanoidLogics;

        [SerializeField]
        protected HumanoidController.HumanoidControllerSettings _humanoidControllerSettings;

        protected override void InitHumanoid() {
            base.InitHumanoid();
            var characterController = GetComponent<CharacterController>();
            _humanoidController = new PlayerHumanoidController(characterController, _pointOfView, _humanoidControllerSettings);
            _humanoid = new PlayerHumanoid(_humanoidController, _humanoidData, _pointOfView);
        }

        protected override void FindHumanoidLogics() {
            base.FindHumanoidLogics();
            _playerHumanoidLogics = GetComponents<PlayerHumanoidLogic>().ToList();
        }

        protected override void InitLogics() {
            base.InitLogics();
            for (int i = 0; i < _playerHumanoidLogics.Count; i++) {
                _playerHumanoidLogics[i].Init(_humanoid);
            }
        }

        protected override void OnUpdate() {
            base.OnUpdate();
            for (int i = 0; i < _playerHumanoidLogics.Count; i++) {
                _playerHumanoidLogics[i].OnUpdate();
            }
        }

        public override void HandleInput(HumanoidInput playerInput) {
            base.HandleInput(playerInput);
            for (int i = 0; i < _playerHumanoidLogics.Count; i++) {
                _playerHumanoidLogics[i].HandleInput(playerInput);
            }
        }
    }
}

