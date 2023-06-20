
namespace Game {

    public class PlayerHumanoidBuildLogic : PlayerHumanoidLogic {

        public override void HandleInput(HumanoidInput playerInput) {
            if (!_humanoid.TrapBuilder.IsActive) {
                return;
            }
            if (playerInput.build) {
                _humanoid.TrapBuilder.BuildTrap(_humanoid.Inventory);
            }
            if (playerInput.rotateTrapScheme) {
                _humanoid.TrapBuilder.Rotate();
            }
        }

        public override void OnUpdate() {
            if (_humanoid.TrapBuilder.IsActive) {
                _humanoid.TrapBuilder.Update();
            }
        }
    }
}
