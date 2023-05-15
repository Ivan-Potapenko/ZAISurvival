using Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {

    public class HumanoidLogicController : MonoBehaviour {

        private Humanoid _humanoid;
        public Humanoid Humanoid => _humanoid;

        private HumanoidController _humanoidController;

        private List<HumanoidLogic> _humanoidLogics;

        [SerializeField]
        private HumanoidData _humanoidData;

        [SerializeField]
        private PointOfView _pointOfView;

        [SerializeField]
        private Camera _camera;

        private void Awake() {
            _humanoidLogics = GetComponents<HumanoidLogic>().ToList();
            var characterController = GetComponent<CharacterController>();
            _humanoidController = new HumanoidController(characterController, _camera);
            _humanoid = new Humanoid(_humanoidController, _humanoidData, _pointOfView);
            InitLogics();
        }

        private void InitLogics() {
            for (int i = 0; i < _humanoidLogics.Count; i++) {
                _humanoidLogics[i].Init(_humanoid);
            }
        }

        private void Update() {
            OnUpdate();
        }

        private void OnUpdate() {
            for (int i = 0; i < _humanoidLogics.Count; i++) {
                _humanoidLogics[i].OnUpdate();
            }
        }

        public void HandleInput(HumanoidInput playerInput) {
            for (int i = 0; i < _humanoidLogics.Count; i++) {
                _humanoidLogics[i].HandleInput(playerInput);
            }
        }
    }
}
