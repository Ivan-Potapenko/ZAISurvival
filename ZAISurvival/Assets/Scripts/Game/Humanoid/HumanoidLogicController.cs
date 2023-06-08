using Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {

    public abstract class HumanoidLogicController<THumanoid, THumanoidData> : MonoBehaviour where THumanoidData : HumanoidData where THumanoid : Humanoid {

        protected THumanoid _humanoid;
        public THumanoid Humanoid => _humanoid;

        protected HumanoidController _humanoidController;

        protected List<HumanoidLogic> _humanoidLogics;

        [SerializeField]
        protected THumanoidData _humanoidData;

        [SerializeField]
        protected PointOfView _pointOfView;

        private void Awake() {
            Init();
        }

        protected virtual void Init() {
            FindHumanoidLogics();
            InitHumanoid();
            InitLogics();
        }

        protected virtual void FindHumanoidLogics() {
            _humanoidLogics = GetComponents<HumanoidLogic>().ToList();
        }

        protected virtual void InitHumanoid() {
        }

        protected virtual void InitLogics() {
            for (int i = 0; i < _humanoidLogics.Count; i++) {
                _humanoidLogics[i].Init(_humanoid);
            }
        }

        private void Update() {
            OnUpdate();
        }

        protected virtual void OnUpdate() {
            for (int i = 0; i < _humanoidLogics.Count; i++) {
                _humanoidLogics[i].OnUpdate();
            }
        }

        public virtual void HandleInput(HumanoidInput playerInput) {
            for (int i = 0; i < _humanoidLogics.Count; i++) {
                _humanoidLogics[i].HandleInput(playerInput);
            }
        }
    }
}
