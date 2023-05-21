using Game;
using TMPro;
using UnityEngine;

namespace UI {

    public class WeaponInterfaceController : MonoBehaviour {

        [SerializeField]
        private WeaponSlotsController _weaponSlotsController;

        private Humanoid _humanoid;

        [SerializeField]
        private TextMeshProUGUI _ammoText;

        [SerializeField]
        private SightController _sightController;

        public void Init(Humanoid humanoid) {
            _humanoid = humanoid;
            _weaponSlotsController.Init();
        }

        public void OnUpdate() {
            UpdateWeaponsSlots();
            UpdateAmmoVisual();
            UpdateSight();

        }

        private void UpdateSight() {
            var weaponUIData = _humanoid.CurrentWeapon.GetWeaponUIData();
            _sightController.UpdateSight(weaponUIData);
        }

        private void UpdateAmmoVisual() {
            var weaponUIData = _humanoid.CurrentWeapon.GetWeaponUIData();
            _ammoText.text = $"{weaponUIData.loadedCartridges}/{weaponUIData.clipSize}";
        }

        private void UpdateWeaponsSlots() {
            _weaponSlotsController.UpdateSlots(_humanoid.GetWeaponsUIData(), _humanoid.CurrentWeaponSlot);
        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}
