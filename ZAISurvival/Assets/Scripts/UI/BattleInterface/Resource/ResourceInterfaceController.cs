using Game;
using UnityEngine;

namespace UI {

    public class ResourceInterfaceController : InterfaceController {

        [SerializeField]
        private ResourceSlotController _resourceSlotController;

        [SerializeField]
        private ItemSlot _buildSlot;

        public override void Init(PlayerHumanoid humanoid) {
            base.Init(humanoid);
            _resourceSlotController.Init();
            _buildSlot.SetActive(true);
        }

        public override void OnUpdate() {
            base.OnUpdate();
            UpdateSlotsController();
            UpdateBuildSlot();
        }

        private void UpdateBuildSlot() {
            var uiData = _humanoid.TrapBuilder.GetCurrentTrapUIData();
            var minCount = _humanoid.Inventory.Get(uiData.necessaryResources[0].resourceType).Count / uiData.necessaryResources[0].count;
            foreach (var necessaryResource in uiData.necessaryResources) {
                var resource = _humanoid.Inventory.Get(necessaryResource.resourceType);
                var buildCount = _humanoid.Inventory.Get(uiData.necessaryResources[0].resourceType).Count / uiData.necessaryResources[0].count;
                if (buildCount < minCount) {
                    minCount = buildCount;
                }
            }
            _buildSlot.UpdateSlot(uiData.icon, _humanoid.TrapBuilder.IsActive, uiData.slotOffset, uiData.slotSize, minCount.ToString());
        }

        private void UpdateSlotsController() {
            _resourceSlotController.UpdateSlots(_humanoid.Inventory.GetUIData());
        }
    }
}