namespace Game {

    public class MoveLogic : HumanoidLogic {

        public override void OnUpdate() {
            
        }

        public override void HandleInput(HumanoidInput playerInput) {
            _humanoid.CurrentState.Move(playerInput.moveDirection);
        }
    }
}
