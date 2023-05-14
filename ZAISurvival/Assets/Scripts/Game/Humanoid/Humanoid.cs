using Data;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using static Game.Humanoid;

namespace Game {

    public class Humanoid {

        public enum StateType {
            Run,
            Stay,
            Crouch,
            Test,
        }

        private Dictionary<StateType, HumanoidState> _states;

        private HumanoidState _currentState;
        public HumanoidState CurrentState => _currentState;

        private Weapon[] _weapons;

        private int _currentWeaponSlot;
        public int CurrentWeaponSlot => _currentWeaponSlot;
        public Weapon CurrentWeapon => _weapons[_currentWeaponSlot - 1];

        private ResourceStorage _resourceStorage;
        public ResourceStorage ResourceStorage => _resourceStorage;

        private AimController _aimController;
        public AimController AimController => _aimController;

        private Health _health;
        public Health Health => _health;

        private PointOfView _pointOfView;
        public PointOfView PointOfView => _pointOfView;

        private LayerMask _enemyLayerMask;
        public LayerMask EnemyLayerMask => _enemyLayerMask;

        public Humanoid(HumanoidController controller, HumanoidData humanoidData, PointOfView pointOfView) {
            _health = new Health(humanoidData.HealthData);
            _pointOfView = pointOfView;
            _enemyLayerMask = humanoidData.EnemyLayerMask;
            InitStates(controller, humanoidData);
            InitWeapons(humanoidData);
        }

        #region State
        private void InitStates(HumanoidController controller, HumanoidData humanoidData) {
            _states = new Dictionary<StateType, HumanoidState> {
                {StateType.Test, new TestHumanoidState(controller, GetStateData(StateType.Test, humanoidData.StateDatas))}
            };
            SetCurrentState(StateType.Test);
        }

        private HumanoidStateData GetStateData(StateType stateType, List<HumanoidStateData> humanoidStateDatas) {
            return humanoidStateDatas.Where(state => state.StateType == stateType).FirstOrDefault();
        }

        public void SetCurrentState(StateType state) {
            if (_states == null) {
                return;
            }
            _currentState = _states[state];
        }
        #endregion State

        #region Weapon
        private void InitWeapons(HumanoidData humanoidData) {
            _weapons = new Weapon[humanoidData.WeaponPrefabs.Count];
            for (int i = 0; i < humanoidData.WeaponPrefabs.Count; i++) {
                _weapons[i] = Object.Instantiate(humanoidData.WeaponPrefabs[i], PointOfView.transform);
                _weapons[i].Init(this);
            }
            ChangeWeaponSlot(1);
        }

        public void ChangeWeaponSlot(int slot) {
            if (slot - 1 > _weapons.Length || slot == _currentWeaponSlot) {
                return;
            }
            _currentWeaponSlot = slot;
            DeactivateWeapon();
            CurrentWeapon.SetActive(true);
        }

        public void DeactivateWeapon() {
            foreach (var weapon in _weapons) {
                weapon.SetActive(false);
            }
        }

        public WeaponUIData[] GetWeaponsUIData() {
            var weaponUIDatas = new WeaponUIData[_weapons.Length];
            for(int i = 0; i< weaponUIDatas.Length;i++) {
                weaponUIDatas[i] = _weapons[i].GetWeaponUIData(); 
            }
            return weaponUIDatas;
        }
        #endregion Weapon
    }
}
