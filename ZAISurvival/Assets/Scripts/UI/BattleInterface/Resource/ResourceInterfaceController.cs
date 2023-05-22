using Game;
using UnityEngine;

namespace UI {

    public class ResourceInterfaceController : InterfaceController {

        [SerializeField]
        private ResourceSlotController _resourceSlotController;

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
            _resourceSlotController.Init();
        }

        public override void OnUpdate() {
            base.OnUpdate();
            UpdateSlotsController();
        }

        private void UpdateSlotsController() {
            _resourceSlotController.UpdateSlots(_humanoid.Inventory.GetUIData());
        }
    }
}