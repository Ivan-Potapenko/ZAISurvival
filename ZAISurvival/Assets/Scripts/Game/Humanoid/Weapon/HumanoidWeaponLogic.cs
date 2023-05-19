namespace Game {

    public class WeaponLogic : HumanoidLogic {

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
        }

        public override void OnUpdate() {
            _humanoid.CurrentWeapon.OnUpdate();
        }

        public override void HandleInput(HumanoidInput playerInput) {
            _humanoid.CurrentState.ForceRotate(_humanoid.CurrentWeapon.GetCameraOffset());
            _humanoid.CurrentState.isAim = playerInput.isAim;
            _humanoid.CurrentWeapon.isAim = playerInput.isAim;
            if (playerInput.selectSlot != -1) {
                _humanoid.ChangeWeaponSlot(playerInput.selectSlot);
            }
            if (playerInput.reload) {
                _humanoid.CurrentWeapon.Reload();
            }
            if (playerInput.isShooting) {
                _humanoid.CurrentWeapon.StartAttacking();
            } else {
                _humanoid.CurrentWeapon.StopAttacking();
            }
        }
    }
}
