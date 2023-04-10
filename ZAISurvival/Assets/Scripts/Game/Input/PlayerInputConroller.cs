using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {

    public class PlayerInputConroller : MonoBehaviour {

        private HumanoidLogicController _humanoidLogicController;

        private PlayerInputActions _inputs;

        private HumanoidInput _currentInput;

        private void Awake() {
            _inputs = new PlayerInputActions();
            _currentInput = new HumanoidInput();
        }

        private void OnEnable() {
            _inputs.Player.Shoot.Enable();
            _inputs.Player.Aim.Enable();
            _inputs.Player.Build.Enable();
            _inputs.Player.Jump.Enable();
            _inputs.Player.Move.Enable();
            _inputs.Player.MouseMove.Enable();
        }

        private void OnDisable() {
            _inputs.Player.Shoot.Disable();
            _inputs.Player.Aim.Disable();
            _inputs.Player.Build.Disable();
            _inputs.Player.Jump.Disable();
            _inputs.Player.Move.Disable();
            _inputs.Player.MouseMove.Disable();
        }

        private void Update() {
            _currentInput.moveDirection = _inputs.Player.Move.ReadValue<Vector2>();
            _currentInput.mouseDelta = _inputs.Player.MouseMove.ReadValue<Vector2>();
            _currentInput.isShooting = _inputs.Player.Shoot.IsPressed();
            _currentInput.isAim = _inputs.Player.Aim.IsPressed();
            _currentInput.isJump = _inputs.Player.Jump.WasPressedThisFrame();
            _currentInput.isBuild = _inputs.Player.Build.WasPressedThisFrame();
            /*Debug.Log("isShooting = " + _currentInput.isShooting +
                " isAim = " + _currentInput.isAim +
                " isBuild = " + _currentInput.isBuild +
                " isJump = " + _currentInput.isJump +
                " moveDirection = " + _currentInput.moveDirection +
                " mouseDelta = " + _currentInput.mouseDelta);*/
            _humanoidLogicController.HandleInput(_currentInput);
        }
    }
}

