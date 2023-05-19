namespace Game {

    public class HumanoidMoveLogic : HumanoidLogic {

        public override void OnUpdate() {
        }

        public override void HandleInput(HumanoidInput playerInput) {
            _humanoid.CurrentState.Move(playerInput.moveDirection);
            if(playerInput.isJump) {
                _humanoid.CurrentState.Jump();
            }
            _humanoid.CurrentState.UpdateAirYPosition();
        }
    }
}
