using Game;

namespace UI {

    public class WeaponSlotsController : SlotsController {

        public void Init() {
        }

        public void UpdateSlots(WeaponUIData[] weaponUIDatas, int activeSlot) {
            DeactivateSlots();
            for (int i = 0; i < weaponUIDatas.Length; i++) {
                UpdateSlot(_slots[i], weaponUIDatas[i].icon, activeSlot == i + 1, weaponUIDatas[i].iconOffset);
            }
        }
    }
}
