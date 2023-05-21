using Game;
using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public class WeaponSlotsController : MonoBehaviour {

        [SerializeField]
        private List<WeaponSlot> _weaponSlots;

        public void Init() {
        }

        public void UpdateSlots(WeaponUIData[] weaponUIDatas, int activeSlot) {
            DeactivateSlots();
            for (int i = 0; i < weaponUIDatas.Length; i++) {
                _weaponSlots[i].UpdateSlot(weaponUIDatas[i].icon, activeSlot == i + 1, weaponUIDatas[i].iconOffset);
                _weaponSlots[i].SetActive(true);
            }
        }

        private void DeactivateSlots() {
            foreach (var slot in _weaponSlots) {
                slot.SetActive(false);
            }
        }
    }
}
