
namespace Game {

    public class PlayerHumanoidBuildLogic : PlayerHumanoidLogic {

        public override void HandleInput(HumanoidInput playerInput) {
            if (_humanoid.TrapBuilder.IsActive && playerInput.build) {
                _humanoid.TrapBuilder.BuildTrap(_humanoid.Inventory);
            }
        }

        public override void OnUpdate() {
            if (_humanoid.TrapBuilder.IsActive) {
                _humanoid.TrapBuilder.Update();
            }
        }
    }
}
