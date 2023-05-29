using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public class BattleInterfaceScreen : InterfaceScreen {

        [SerializeField]
        private List<InterfaceController> _interfaceControllers;

        public override void Show() {
            base.Show();
            Cursor.lockState = CursorLockMode.Locked;
            foreach (var controller in _interfaceControllers) {
                controller.Init(_interfaceScreenData.humanoid);
                controller.SetActive(true);
            }
        }

        private void Update() {
            foreach (var controller in _interfaceControllers) {
                controller.OnUpdate();
            }
        }

        public override void Hide() {
            base.Hide();
            Cursor.lockState = CursorLockMode.None;
            foreach (var controller in _interfaceControllers) {
                controller.SetActive(false);
            }
        }
    }
}

