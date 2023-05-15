using UnityEngine;

namespace UI {

    public class BattleInterfaceScreen : InterfaceScreen {

        [SerializeField]
        private WeaponInterfaceController _weaponInterfaceController;

        public override void Show() {
            base.Show();
            Cursor.lockState = CursorLockMode.Locked;
            _weaponInterfaceController.Init(_interfaceScreenData.humanoid);
            _weaponInterfaceController.SetActive(true);
        }

        private void Update() {
            _weaponInterfaceController.OnUpdate();
        }

        public override void Hide() {
            base.Hide();
            _weaponInterfaceController.SetActive(false);
        }
    }
}

