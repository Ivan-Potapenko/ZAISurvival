using UnityEngine;

namespace Game {

    public class PlayerInputConroller : MonoBehaviour {

        private HumanoidLogicController _humanoidLogicController;

        private PlayerInputActions _inputs;

        private HumanoidInput _currentInput;

        private bool _inited = false;

        public void Init(HumanoidLogicController player) {
            _humanoidLogicController = player;
            _inputs = new PlayerInputActions();
            _currentInput = new HumanoidInput();
            _inited = true;
            EnableInputs();
        }

        private void OnEnable() {
            EnableInputs();
        }

        private void EnableInputs() {
            if (!_inited) {
                return;
            }
            _inputs.Player.Shoot.Enable();
            _inputs.Player.Aim.Enable();
            _inputs.Player.Build.Enable();
            _inputs.Player.Jump.Enable();
            _inputs.Player.Move.Enable();
            _inputs.Player.MouseMove.Enable();
            _inputs.Player.SelectSlot_1.Enable();
            _inputs.Player.SelectSlot_2.Enable();
            _inputs.Player.SelectSlot_3.Enable();
            _inputs.Player.Reload.Enable();
            _inputs.Player.Run.Enable();
            _inputs.Player.Crouch.Enable();
            _inputs.Player.Interact.Enable();
        }

        private void OnDisable() {
            _inputs.Player.Shoot.Disable();
            _inputs.Player.Aim.Disable();
            _inputs.Player.Build.Disable();
            _inputs.Player.Jump.Disable();
            _inputs.Player.Move.Disable();
            _inputs.Player.MouseMove.Disable();
            _inputs.Player.SelectSlot_1.Disable();
            _inputs.Player.SelectSlot_2.Disable();
            _inputs.Player.SelectSlot_3.Disable();
            _inputs.Player.Reload.Disable();
            _inputs.Player.Run.Disable();
            _inputs.Player.Crouch.Disable();
            _inputs.Player.Interact.Disable();
        }

        private void Update() {
            HandleInput();
        }

        private void HandleInput() {
            if (!_inited) {
                return;
            }
            _currentInput.moveDirection = _inputs.Player.Move.ReadValue<Vector2>();
            _currentInput.mouseDelta = _inputs.Player.MouseMove.ReadValue<Vector2>();
            _currentInput.isShooting = _inputs.Player.Shoot.IsPressed();
            _currentInput.isAim = _inputs.Player.Aim.IsPressed();
            _currentInput.isJump = _inputs.Player.Jump.WasPressedThisFrame();
            _currentInput.isBuild = _inputs.Player.Build.WasPressedThisFrame();
            _currentInput.selectSlot = _inputs.Player.SelectSlot_1.WasPressedThisFrame() ? 1 :
                _inputs.Player.SelectSlot_2.WasPressedThisFrame() ? 2 : _inputs.Player.SelectSlot_3.WasPressedThisFrame() ? 3 : -1;
            _currentInput.reload = _inputs.Player.Reload.WasPressedThisFrame();
            _currentInput.isRun = _inputs.Player.Run.IsPressed();
            _currentInput.isCrouch = _inputs.Player.Crouch.IsPressed();
            _currentInput.interact = _inputs.Player.Interact.IsPressed();
            _humanoidLogicController.HandleInput(_currentInput);
        }
    }
}

