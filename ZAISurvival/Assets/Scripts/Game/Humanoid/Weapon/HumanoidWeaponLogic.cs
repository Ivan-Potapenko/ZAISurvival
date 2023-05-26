
using UnityEngine;

namespace Game {

    public class PlayerWeaponLogic : PlayerRotationLogic {

        public override void OnUpdate() {
            if(_humanoid.CurrentWeapon != null) {
                _humanoid.CurrentWeapon.OnUpdate();
            }
        }

        public override void HandleInput(HumanoidInput playerInput) {
            if (_humanoid.CurrentWeapon == null) {
                return;
            }
            _humanoid.CurrentState.IsAim = playerInput.isAim;
            _humanoid.CurrentState.ForceRotate(_humanoid.CurrentWeapon.GetCameraOffset(), _humanoid.Settings.MinYRotate, _humanoid.Settings.MaxYRotate);
            _humanoid.CurrentWeapon.isAim = _humanoid.CurrentState.IsAim;
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
