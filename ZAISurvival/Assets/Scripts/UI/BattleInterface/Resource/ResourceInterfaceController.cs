using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public class ResourceInterfaceController : MonoBehaviour {

        [SerializeField]
        private ResourceSlotController _resourceSlotController;

        private Humanoid _humanoid;

        public void Init(Humanoid humanoid) {
            _humanoid = humanoid;
            _resourceSlotController.Init();
        }

        public void OnUpdate() {
            UpdateSlotsController();
        }

        private void UpdateSlotsController() {
            _resourceSlotController.UpdateSlots(_humanoid.Inventory.GetUIData());
        }

        public void SetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}