using UnityEngine;

namespace UI {

    public class BattleInterfaceScreen : InterfaceScreen {

        [SerializeField]
        private WeaponInterfaceController _weaponInterfaceController;

        [SerializeField]
        private ResourceInterfaceController _resourceInterfaceController;

        public override void Show() {
            base.Show();
            Cursor.lockState = CursorLockMode.Locked;
            _weaponInterfaceController.Init(_interfaceScreenData.humanoid);
            _weaponInterfaceController.SetActive(true);
            _resourceInterfaceController.Init(_interfaceScreenData.humanoid);
            _resourceInterfaceController.SetActive(true);
        }

        private void Update() {
            _weaponInterfaceController.OnUpdate();
            _resourceInterfaceController.OnUpdate();
        }

        public override void Hide() {
            base.Hide();
            _weaponInterfaceController.SetActive(false);
            _resourceInterfaceController.SetActive(false);
        }
    }
}

