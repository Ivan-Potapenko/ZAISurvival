namespace Game {

    public class HumanoidRotationLogic : HumanoidLogic {

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
        }

        public override void OnUpdate() {
        }

        public override void HandleInput(HumanoidInput playerInput) {
            _humanoid.CurrentState.Rotate(playerInput.mouseDelta);
        }
    }
}

