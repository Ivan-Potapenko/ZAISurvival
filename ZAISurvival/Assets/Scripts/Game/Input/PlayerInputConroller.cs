using UI;
using UnityEngine;

namespace Game {

    public class PlayerInputConroller : MonoBehaviour {

        private PlayerLogicController _humanoidLogicController;

        private PlayerInputActions _inputs;

        private HumanoidInput _currentInput;

        private UIManager _uiManager;

        private bool _inited = false;

        public void Init(PlayerLogicController player, UIManager uiManager) {
            _humanoidLogicController = player;
            _inputs = new PlayerInputActions();
            _currentInput = new HumanoidInput();
            _inited = true;
            _uiManager = uiManager;
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
            _inputs.Player.ActivateBuildScheme.Enable();
            _inputs.Player.OpenBuildMenu.Enable();
            _inputs.Player.RotateTrapScheme.Enable();
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
            _inputs.Player.ActivateBuildScheme.Disable();
            _inputs.Player.OpenBuildMenu.Disable();
            _inputs.Player.RotateTrapScheme.Disable();
        }

        private void Update() {
            HandleInput();
        }

        private void HandleInput() {
            if (!_inited) {
                return;
            }
            if (_inputs.Player.OpenBuildMenu.WasPressedThisFrame()) {
                ActivateBuildMenu();
            }
            _currentInput.moveDirection = _inputs.Player.Move.ReadValue<Vector2>();
            if (_uiManager.CurrentScreen != ScreenType.BuildMenu) {
                _currentInput.mouseDelta = _inputs.Player.MouseMove.ReadValue<Vector2>();
                _currentInput.isShooting = _inputs.Player.Shoot.IsPressed();
                _currentInput.build = _inputs.Player.Shoot.WasPressedThisFrame();
                _currentInput.isAim = _inputs.Player.Aim.IsPressed();
                _currentInput.interact = _inputs.Player.Interact.IsPressed();
                _currentInput.reload = _inputs.Player.Reload.WasPressedThisFrame();
                _currentInput.selectSlot = _inputs.Player.SelectSlot_1.WasPressedThisFrame() ? 1 :
               _inputs.Player.SelectSlot_2.WasPressedThisFrame() ? 2 : _inputs.Player.SelectSlot_3.WasPressedThisFrame() ? 3 : -1;
                _currentInput.activateBuildScheme = _inputs.Player.ActivateBuildScheme.WasPressedThisFrame();
                _currentInput.rotateTrapScheme = _inputs.Player.RotateTrapScheme.IsPressed();
            } else {
                _currentInput.mouseDelta = Vector2.zero;
                _currentInput.isShooting = false;
                _currentInput.build = false;
                _currentInput.isAim = false;
                _currentInput.interact = false;
                _currentInput.reload = false;
                _currentInput.selectSlot = -1;
                _currentInput.activateBuildScheme = false;
                _currentInput.rotateTrapScheme = false;
            }
            _currentInput.isJump = _inputs.Player.Jump.WasPressedThisFrame();
            _currentInput.isBuild = _inputs.Player.Build.WasPressedThisFrame();
            _currentInput.isRun = _inputs.Player.Run.IsPressed();
            _currentInput.isCrouch = _inputs.Player.Crouch.IsPressed();
            _humanoidLogicController.HandleInput(_currentInput);
        }

        private void ActivateBuildMenu() {
            if (_uiManager.CurrentScreen == ScreenType.BuildMenu) {
                _uiManager.ActivateScreen(ScreenType.Battle, new InterfaceScreenData { humanoid = _humanoidLogicController.Humanoid });
            } else {
                _uiManager.ActivateScreen(ScreenType.BuildMenu, new InterfaceScreenData { humanoid = _humanoidLogicController.Humanoid });
            }
        }
    }
}

