using Data;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

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
        public Weapon CurrentWeapon => _weapons[_currentWeaponSlot];

        private ResourceStorage _resourceStorage;
        public ResourceStorage ResourceStorage => _resourceStorage;

        private AimController _aimController;
        public AimController AimController => _aimController;

        private Health _health;
        public Health Health => _health;

        private PointOfView _pointOfView;
        public PointOfView PointOfView => _pointOfView;

        public Humanoid(HumanoidController controller, HumanoidData humanoidData, PointOfView pointOfView) {
            _health = new Health(humanoidData.HealthData);
            _pointOfView = pointOfView;
            InitStates(controller, humanoidData);
            InitWeapons(humanoidData);
        }

        #region State
        private void InitStates(HumanoidController controller, HumanoidData humanoidData) {
            _states = new Dictionary<StateType, HumanoidState>();
            _states.Add(StateType.Test,
                new TestHumanoidState(controller, humanoidData.StateDatas.Where(state => state.StateType == StateType.Test).FirstOrDefault()));
            SetCurrentState(StateType.Test);
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
            ChangeWeaponSlot(0);
        }

        public void ChangeWeaponSlot(int slot) {
            if (slot > _weapons.Length || slot == _currentWeaponSlot) {
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
        #endregion Weapon
    }
}
