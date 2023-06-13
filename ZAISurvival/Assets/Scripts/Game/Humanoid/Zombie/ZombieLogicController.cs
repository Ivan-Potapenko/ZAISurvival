using Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Game {

    public class ZombieLogicController : HumanoidLogicController<ZombieHumanoid, ZombieHumanoidData> {

        private List<ZombieLogic> _zombieHumanoidLogics;

        [SerializeField]
        protected NavMeshHumanoidController.NavMesControllerSettings _humanoidControllerSettings;

        protected override void InitHumanoid() {
            base.InitHumanoid();
            var navMeshAgent = GetComponent<NavMeshAgent>();
            _humanoidController = new NavMeshHumanoidController(navMeshAgent, _humanoidControllerSettings);
            _humanoid = new ZombieHumanoid(_humanoidController, _humanoidData, _pointOfView);
        }


        protected override void FindHumanoidLogics() {
            base.FindHumanoidLogics();
            _zombieHumanoidLogics = GetComponents<ZombieLogic>().ToList();
        }

        protected override void InitLogics() {
            base.InitLogics();
            for (int i = 0; i < _zombieHumanoidLogics.Count; i++) {
                _zombieHumanoidLogics[i].Init(_humanoid);
            }
        }

        protected override void OnUpdate() {
            base.OnUpdate();
            for (int i = 0; i < _zombieHumanoidLogics.Count; i++) {
                _zombieHumanoidLogics[i].OnUpdate();
            }
        }

        public override void HandleInput(HumanoidInput playerInput) {
            base.HandleInput(playerInput);
            for (int i = 0; i < _zombieHumanoidLogics.Count; i++) {
                _zombieHumanoidLogics[i].HandleInput(playerInput);
            }
        }
    }
}
