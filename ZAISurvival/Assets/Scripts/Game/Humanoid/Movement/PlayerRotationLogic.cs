namespace Game {

    public class PlayerRotationLogic : PlayerHumanoidLogic {

        public override void OnUpdate() {
        }

        public override void HandleInput(HumanoidInput playerInput) {
            _humanoid.CurrentState.Rotate(playerInput.mouseDelta, _humanoid.Settings.RotationSpeed, _humanoid.Settings.MinYRotate,
                _humanoid.Settings.MaxYRotate);
        }
    }
}

