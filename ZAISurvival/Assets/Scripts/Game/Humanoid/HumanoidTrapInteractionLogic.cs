using Game;
using UnityEngine;

namespace Game {

    public class HumanoidTrapInteractionLogic : HumanoidLogic {

        public override void HandleInput(HumanoidInput playerInput) {
        }

        public override void OnUpdate() {

        }

        public void EnterStopTrapState(Trap trap) {
            _humanoid.SetControllableState(Humanoid.StateType.ControllableStop, trap);
        }

        public void ExiteStopTrapState(Trap trap) {
            if(_humanoid.CurrentState.StateData.StateType == Humanoid.StateType.ControllableStop) {
                _humanoid.ExitControllableState(trap);
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit) {
            if(hit.gameObject.TryGetComponent<Trap>(out var trap)) {
            }
        }
    }
}

