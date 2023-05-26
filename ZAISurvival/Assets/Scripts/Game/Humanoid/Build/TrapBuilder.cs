using Data;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class TrapBuilder {

        private Dictionary<TrapSchemeData.TrapSchemeType, TrapSchemeData> _traps = new Dictionary<TrapSchemeData.TrapSchemeType, TrapSchemeData>();
        private Dictionary<TrapSchemeData.TrapSchemeType, TrapScheme> _trapSchemes = new Dictionary<TrapSchemeData.TrapSchemeType, TrapScheme>();

        private TrapSchemeData.TrapSchemeType _currentTrapType;

        private TrapScheme CurrentTrapScheme => _trapSchemes.ContainsKey(_currentTrapType) ? _trapSchemes[_currentTrapType] : null;

        private Transform _trapRoot;

        public bool IsActive { get; private set; }

        public TrapBuilder(TrapSchemeData[] trapSchemeDatas, PointOfView pointOfView, PlayerSettings playerSettings) {
            var root = new GameObject("TrapsShemes");
            _trapRoot = new GameObject("Traps").transform;
            foreach (var trap in trapSchemeDatas) {
                _traps.Add(trap.Type, trap);
                _trapSchemes.Add(trap.Type, GameObject.Instantiate(trap.TrapSchemePrefab, root.transform));
                _trapSchemes[trap.Type].Init(pointOfView, playerSettings);
                _trapSchemes[trap.Type].SetActive(false);
            }
            _currentTrapType = trapSchemeDatas[0].Type;
            Deactivate();
        }

        public void SelectTrap(TrapSchemeData.TrapSchemeType trapSchemeType) {
            if(!_trapSchemes.ContainsKey(trapSchemeType)) {
                return;
            }
            if(CurrentTrapScheme != null) {
                CurrentTrapScheme.SetActive(false);
            }
            _currentTrapType = trapSchemeType;
            CurrentTrapScheme.SetActive(true);
        }

        public void BuildTrap(HumanoidInventory humanoidInventory) {
            if (CurrentTrapScheme == null || !CurrentTrapScheme.CanBuild) {
                return;
            }
            bool canBuild = true;
            foreach (var resource in _traps[_currentTrapType].NecessaryResources) {
                canBuild = humanoidInventory.Get(resource.resourceType).Count >= resource.count;
            }
            if (!canBuild) {
                return;
            }
            foreach (var resource in _traps[_currentTrapType].NecessaryResources) {
                humanoidInventory.Get(resource.resourceType).PullResource(resource.count);
            }
            GameObject.Instantiate(_traps[_currentTrapType].TrapPrefab, _trapSchemes[_currentTrapType].transform.position, _trapSchemes[_currentTrapType].transform.rotation, _trapRoot.transform);
        }

        public void Activate() {
            IsActive = true;
            CurrentTrapScheme.SetActive(true);
        }

        public void Deactivate() {
            IsActive = false;
            CurrentTrapScheme.SetActive(false);
        }

        public void Update() {
            if(CurrentTrapScheme != null) {
                CurrentTrapScheme.OnUpdate();
            }
        }
    }
}

