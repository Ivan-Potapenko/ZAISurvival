using System.Collections;
using UnityEngine;

namespace Game {

    public class EnvironmentVisionHumanoidLogic : PlayerHumanoidLogic {

        private bool _isActive = false;

        public override void Init(PlayerHumanoid humanoid) {
            base.Init(humanoid);
            Enable();
        }

        public override void HandleInput(HumanoidInput playerInput) { }

        public override void OnUpdate() { }

        private void OnEnable() {
            Enable();
        }

        private void Enable() {
            if (_humanoid != null && !_isActive) {
                StartCoroutine(VisionUpdateCoroutine());
                _isActive = true;
            }
        }

        private IEnumerator VisionUpdateCoroutine() {
            while (true) {
                TryFindEnvironment();
                yield return new WaitForSeconds(_humanoid.Settings.TimeBetweenUpdateVision);
            }
        }

        private bool TryFindEnvironment() {
            if (Physics.Raycast(_humanoid.PointOfView.transform.position, _humanoid.PointOfView.transform.forward, out var hitInfo, _humanoid.Settings.VisionDistance, _humanoid.Settings.VisibleLayers.value)) {
                if (hitInfo.collider != null && hitInfo.collider.gameObject.TryGetComponent<InteractiveEnvironmentObject>(out var environmentObject)) {
                    _humanoid.currentObjectInSight = environmentObject;
                    return true;
                }
            }
            _humanoid.currentObjectInSight = null;
            return false;
        }

        private void OnDisable() {
            StopAllCoroutines();
            _isActive = false;
        }
    }
}
