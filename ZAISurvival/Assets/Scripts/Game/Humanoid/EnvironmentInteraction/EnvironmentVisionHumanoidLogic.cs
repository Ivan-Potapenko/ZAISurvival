using System.Collections;
using UnityEngine;

namespace Game {

    public class EnvironmentVisionHumanoidLogic : HumanoidLogic {

        [SerializeField]
        private float _visionDistance;

        [SerializeField]
        private float _timeBetweenUpdateVision;

        [SerializeField]
        private LayerMask _visibleLayers;

        public override void HandleInput(HumanoidInput playerInput) { }

        public override void OnUpdate() { }

        private void OnEnable() {
            StartCoroutine(VisionUpdateCoroutine());
        }

        private IEnumerator VisionUpdateCoroutine() {
            while (true) {
                TryFindEnvironment();
                yield return new WaitForSeconds(_timeBetweenUpdateVision);
            }
        }

        private bool TryFindEnvironment() {
            if (Physics.Raycast(_humanoid.PointOfView.transform.position, _humanoid.PointOfView.transform.forward, out var hitInfo, _visionDistance, _visibleLayers.value)) {
                if (hitInfo.collider.gameObject.TryGetComponent<InteractiveEnvironmentObject>(out var environmentObject)) {
                    _humanoid.currentObjectInSight = environmentObject;
                    return true;
                }
            }
            _humanoid.currentObjectInSight = null;
            return false;
        }

        private void OnDisable() {
            StopAllCoroutines();
        }
    }
}
