namespace Game {

    public class WeaponLogic : HumanoidLogic {

        public override void Init(Humanoid humanoid) {
            base.Init(humanoid);
        }

        public override void OnUpdate() {
            _humanoid.CurrentWeapon.OnUpdate();
        }

        public override void HandleInput(HumanoidInput playerInput) {
            if (playerInput.isShooting) {
                _humanoid.CurrentWeapon.StartAttacking();
            } else {
                _humanoid.CurrentWeapon.StopAttacking();
            }
        }
    }
}
