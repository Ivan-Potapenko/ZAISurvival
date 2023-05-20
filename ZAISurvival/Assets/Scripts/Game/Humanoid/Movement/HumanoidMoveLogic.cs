using UnityEngine;

namespace Game {

    public class HumanoidMoveLogic : HumanoidLogic {

        public override void OnUpdate() {
        }

        public override void HandleInput(HumanoidInput playerInput) {
            Debug.Log(_humanoid.CurrentState.StateData.StateType);
            if (playerInput.isRun) {
                _humanoid.CurrentState.Run(playerInput.moveDirection);
            } else if(playerInput.isCrouch) {
                _humanoid.CurrentState.Crouch(playerInput.moveDirection);
            } else {
                _humanoid.CurrentState.Move(playerInput.moveDirection);
            }
            if (playerInput.isJump) {
                _humanoid.CurrentState.Jump();
            }
            _humanoid.CurrentState.Update();
        }
    }
}
