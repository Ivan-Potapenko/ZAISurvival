using Game;
using System.Collections.Generic;
using UnityEngine;
using static Data.TrapSchemeData;

namespace UI {

    public class BuildMenu : MonoBehaviour {

        [SerializeField]
        private List<BuildMenuItem> _buildMenuItems;

        private UIManager _manager;

        private PlayerHumanoid _playerHumanoid;

        public void Init(PlayerHumanoid playerHumanoid, UIManager uiManager) {
            _manager = uiManager;
            _playerHumanoid = playerHumanoid;
            for (int i = 0; i < _buildMenuItems.Count; i++) {
                _buildMenuItems[i].Init(SelectTrap);
            }
            DeactivateSlots();
        }

        private void SelectTrap(TrapSchemeType trapSchemeType) {
            _playerHumanoid.TrapBuilder.SelectTrap(trapSchemeType);
            _manager.ActivateScreen(ScreenType.Battle, new InterfaceScreenData { humanoid = _playerHumanoid });
        }

        public void Update() {
            UpdateSlots(_playerHumanoid.TrapBuilder.GetTrapBuilderUIDatas());
        }

        public void UpdateSlots(TrapBuilderUIData[] buildUIDatas) {
            DeactivateSlots();
            for (int i = 0; i < buildUIDatas.Length; i++) {
                _buildMenuItems[i].UpdateSlot(buildUIDatas[i]);
                _buildMenuItems[i].SetActive(true);
            }
        }

        protected void DeactivateSlots() {
            foreach (var slot in _buildMenuItems) {
                slot.SetActive(false);
            }
        }

        public void SetActive(bool enable) {
            gameObject.SetActive(enable);
        }
    }
}
