using Data;
using Game;

namespace UI {

    public class ResourceSlotController : SlotsController {

        public void Init() {
        }

        public void UpdateSlots(ResourceUIData[] uiDatas) {
            DeactivateSlots();
            for (int i = 0; i < uiDatas.Length; i++) {
                UpdateSlot(_slots[i], uiDatas[i].icon, true, uiDatas[i].position, uiDatas[i].count.ToString());
            }
        }
    }
}