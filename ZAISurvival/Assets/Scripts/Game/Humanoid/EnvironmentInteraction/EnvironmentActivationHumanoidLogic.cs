using UnityEngine;

namespace Game {

    public class EnvironmentActivationHumanoidLogic : HumanoidLogic {

        public override void HandleInput(HumanoidInput playerInput) {
            if (playerInput.interact && _humanoid.currentObjectInSight != null) {
                _humanoid.currentObjectInSight.Interact(_humanoid);
            }
        }

        public override void OnUpdate() {
        }
    }
}
