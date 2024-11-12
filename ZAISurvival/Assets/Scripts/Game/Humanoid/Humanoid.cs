using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game {

    public class Humanoid {

        public enum StateType {
            Stand,
            Run,
            Crouch,
            Test,
            Walk,
            ControllableStop,
            Attack,
        }

        private Dictionary<StateType, HumanoidState> _states;

        private HumanoidState _currentState;
        public HumanoidState CurrentState => _currentState;

        private HumanoidState _prevState;
        public HumanoidState PrevState => _prevState;

        private Weapon[] _weapons;

        private int _currentWeaponSlot;
        public int CurrentWeaponSlot => _currentWeaponSlot;
        public Weapon CurrentWeapon => _currentWeaponSlot >= 0 && _currentWeaponSlot <= _weapons.Length ? _weapons[_currentWeaponSlot - 1] : null;

        private Health _health;
        public Health Health => _health;

        private PointOfView _pointOfView;
        public PointOfView PointOfView => _pointOfView;

        private LayerMask _enemyLayerMask;
        public LayerMask EnemyLayerMask => _enemyLayerMask;

        private HumanoidData _humanoidData;

        public InteractiveEnvironmentObject currentObjectInSight;

        public HumanoidInventory Inventory { get; private set; }

        public Trap CurrentTrap { get; private set; }

        public Humanoid(HumanoidController controller, HumanoidData humanoidData, PointOfView pointOfView) {
            _health = new Health(humanoidData.HealthData);
            _pointOfView = pointOfView;
            _enemyLayerMask = humanoidData.EnemyLayerMask;
            _humanoidData = humanoidData;
            if(humanoidData.ResourceDatas != null) {
                Inventory = new HumanoidInventory(humanoidData.ResourceDatas);
            }
            InitStates(controller);
            InitWeapons();
        }

        #region State
        private void InitStates(HumanoidController controller) {
            _states = new Dictionary<StateType, HumanoidState>();
            foreach (StateType state in Enum.GetValues(typeof(StateType))) {
                TryAddState(state, controller);
            }
            SetCurrentState(_humanoidData.StateDatas[0].StateType);
        }

        private bool TryAddState(StateType stateType, HumanoidController controller) {
            var stateData = GetStateData(stateType);
            if (stateData == null) {
                return false;
            }
            var state = GetNewHumanoidState(stateType, controller, stateData);
            if(state == null) {
                return false;
            }
            _states.Add(stateType, state);
            return true;
        }

        protected virtual HumanoidState GetNewHumanoidState(StateType stateType, HumanoidController controller, HumanoidStateData stateData) {
            switch (stateType) {
                case StateType.Walk:
                    return new WalkHumanoidState(controller, stateData, SetCurrentState);
                case StateType.Run:
                    return new RunHumanoidState(controller, stateData, SetCurrentState);
                case StateType.Stand:
                    return new StandHumanoidState(controller, stateData, SetCurrentState);
                case StateType.Test:
                    return new TestHumanoidState(controller, stateData, SetCurrentState);
                case StateType.Crouch:
                    return new CrouchHumanoidState(controller, stateData, SetCurrentState);
                case StateType.ControllableStop:
                    return new ControllableStopState(controller, stateData, SetCurrentState);
                default:
                    return null;
            }
        }

        private HumanoidStateData GetStateData(StateType stateType) {
            return _humanoidData.StateDatas.Where(state => state.StateType == stateType).FirstOrDefault();
        }

        public HumanoidState SetCurrentState(StateType state) {
            if (_states == null || !_states.ContainsKey(state)) {
                return null;
            }
            _prevState = _currentState;
            _currentState = _states[state];
            _currentState.Activate();
            return _currentState;
        }

        public virtual void SetControllableState(StateType stateType, Trap trap) {
            SetCurrentState(stateType);
            CurrentTrap = trap;
        }

        public virtual void ExitControllableState(Trap trap) {
            SetCurrentState(_humanoidData.StateDatas[0].StateType);
            CurrentTrap = null;
        }
        #endregion State

        #region Weapon
        private void InitWeapons() {
            if(_humanoidData.WeaponPrefabs == null || _humanoidData.WeaponPrefabs.Count == 0) {
                return;
            }
            _weapons = new Weapon[_humanoidData.WeaponPrefabs.Count];
            for (int i = 0; i < _humanoidData.WeaponPrefabs.Count; i++) {
                _weapons[i] = UnityEngine.Object.Instantiate(_humanoidData.WeaponPrefabs[i], PointOfView.transform);
                _weapons[i].Init(this);
            }
            ChangeWeaponSlot(1);
        }

        public void ChangeWeaponSlot(int slot) {
            if (_weapons == null || slot - 1 > _weapons.Length || slot == _currentWeaponSlot) {
                return;
            }
            DeactivateWeapon();
            _currentWeaponSlot = slot;
            CurrentWeapon.SetActive(true);
        }

        public void DeactivateWeapon() {
            if (_weapons == null) {
                return;
            }
            foreach (var weapon in _weapons) {
                weapon.SetActive(false);
            }
            _currentWeaponSlot = -1;
        }

        public WeaponUIData[] GetWeaponsUIData() {
            var weaponUIDatas = new WeaponUIData[_weapons.Length];
            for (int i = 0; i < weaponUIDatas.Length; i++) {
                weaponUIDatas[i] = _weapons[i].GetWeaponUIData();
            }
            return weaponUIDatas;
        }
        #endregion Weapon
    }
}
