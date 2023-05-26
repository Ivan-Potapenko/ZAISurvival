namespace Game {

    public class PlayerHumanoidSlotsLogic : PlayerHumanoidLogic {

        public override void HandleInput(HumanoidInput playerInput) {
            if(playerInput.activateBuildScheme) {
                _humanoid.TrapBuilder.Activate();
                _humanoid.DeactivateWeapon();
            }
            else if (playerInput.selectSlot != -1) {
                if(_humanoid.TrapBuilder.IsActive) {
                    _humanoid.TrapBuilder.Deactivate();
                }
                _humanoid.ChangeWeaponSlot(playerInput.selectSlot);
            }
        }

        public override void OnUpdate() {
        }
    }
}
