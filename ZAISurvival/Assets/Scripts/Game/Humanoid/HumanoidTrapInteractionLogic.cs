using Game;
using UnityEngine;

namespace Game {

    public class HumanoidTrapInteractionLogic : HumanoidLogic {

        public override void HandleInput(HumanoidInput playerInput) {
        }

        public override void OnUpdate() {

        }

        public void EnterStopTrapState() {
            _humanoid.SetControllableState(Humanoid.StateType.ControllableStop);
        }

        public void ExiteStopTrapState() {
            if(_humanoid.CurrentState.StateData.StateType == Humanoid.StateType.ControllableStop) {
                _humanoid.ExitControllableState();
            }
        }
    }
}

