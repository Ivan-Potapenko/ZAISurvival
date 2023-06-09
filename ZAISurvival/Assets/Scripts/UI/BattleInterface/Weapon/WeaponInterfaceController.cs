using Game;
using TMPro;
using UnityEngine;

namespace UI {

    public class WeaponInterfaceController : InterfaceController {

        [SerializeField]
        private WeaponSlotsController _weaponSlotsController;

        [SerializeField]
        private TextMeshProUGUI _ammoText;

        [SerializeField]
        private SightController _sightController;

        public override void Init(PlayerHumanoid humanoid) {
            base.Init(humanoid);
            _weaponSlotsController.Init();
        }

        public override void OnUpdate() {
            base.OnUpdate();
            UpdateWeaponsSlots();
            UpdateAmmoVisual();
            UpdateSight();

        }

        private void UpdateSight() {
            if (_humanoid.CurrentWeapon == null) {
                return;
            }
            var weaponUIData = _humanoid.CurrentWeapon.GetWeaponUIData();
            _sightController.UpdateSight(weaponUIData);
        }

        private void UpdateAmmoVisual() {
            if(_humanoid.CurrentWeapon == null) {
                return;
            }
            var weaponUIData = _humanoid.CurrentWeapon.GetWeaponUIData();
            _ammoText.text = $"{weaponUIData.loadedCartridges}/{weaponUIData.clipSize}";
        }

        private void UpdateWeaponsSlots() {
            _weaponSlotsController.UpdateSlots(_humanoid.GetWeaponsUIData(), _humanoid.CurrentWeaponSlot);
        }
    }
}
