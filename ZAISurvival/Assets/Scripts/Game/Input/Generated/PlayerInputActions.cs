//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Resources/Controller/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game
{
    public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""a6c2d6d6-6f7d-4716-a1e9-ee8deb1439e1"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""886e01ce-5abf-4775-86d5-30690dde64a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""134d7163-067f-4555-b8e4-1fcb0a8c5b3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1094f181-36b0-4e29-96f3-2d9210fbeb9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""cecfa814-5362-4ad7-960a-5ee645560b57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""102a7e25-6f90-4f13-a9b6-b77ae3d58793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""92204e0e-c711-4c54-98b2-21192d57a88e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectSlot_1"",
                    ""type"": ""Button"",
                    ""id"": ""ec2dfb81-8ba3-45d8-927c-b4693e19fe48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot_2"",
                    ""type"": ""Button"",
                    ""id"": ""f1136ad6-c3e9-4bb7-a8cb-f2a3a0d238d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot_3"",
                    ""type"": ""Button"",
                    ""id"": ""50d77494-2492-4f0a-9819-e181a6146d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""f3d2b8ed-9a02-4fb9-bcd6-5fccd96740fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""a1df07a8-37eb-412e-b8dd-23e2a82c7283"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""ab37051f-4ab8-4bb1-9ec1-4e5b3c4f073b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8ecbf5a5-6c72-4d51-b89b-0a8d64e5e495"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActivateBuildScheme"",
                    ""type"": ""Button"",
                    ""id"": ""c394ca50-7cec-4a2a-8d80-4b5fbf34a359"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenBuildMenu"",
                    ""type"": ""Button"",
                    ""id"": ""5bcec882-e0cc-46eb-abc5-1abfebbef7b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateTrapScheme"",
                    ""type"": ""Button"",
                    ""id"": ""8047403b-55ff-4774-8904-d6271dc33272"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65983916-8b57-441f-8dda-205c21342fc2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6c8489c8-7df6-40e7-ab8a-8a18667caa84"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b034cceb-6d9f-4ad5-810a-82cf6206a3ec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c7e1b35c-b850-4099-8ee5-0c711f5eebc1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b257f81-18ba-4a1a-a09b-f347139c3dde"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7413753b-35db-4f6c-82f3-47930bd7bf2c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a402d310-8897-4dc8-b7d5-96e7576a6621"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ecb9903-16b4-465a-ab94-a7ed7371e3c0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b497d262-f386-42e4-b978-b955404e8db6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1839f5b9-2d79-4016-adf9-8306ae352d2b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2e0815e-b45e-4f1b-9b53-cda57694a94a"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""SelectSlot_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e821f25d-ec10-4f7d-ba42-8ab07fcca394"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""SelectSlot_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b22f0e6c-bb7d-49b0-bf56-2f1276e79173"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""SelectSlot_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f48e3df-f4f5-4e54-9807-ef750ee32323"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ae0a2e3-b5f6-4179-b331-00acc5b1bc99"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce5ed00d-da06-48f5-a7a2-5a76d1f04b65"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""243b0dbc-d8db-47d0-b7a6-579b0ecdefd4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2db1ebd6-da50-46af-8b25-eefe26a5fa4e"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""ActivateBuildScheme"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70a421ae-e069-4211-bc27-ef992481f8c3"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""OpenBuildMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6910cf81-d895-45bd-b6ac-55934426f336"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateTrapScheme"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard+Mouse"",
            ""bindingGroup"": ""Keyboard+Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
            m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
            m_Player_Build = m_Player.FindAction("Build", throwIfNotFound: true);
            m_Player_MouseMove = m_Player.FindAction("MouseMove", throwIfNotFound: true);
            m_Player_SelectSlot_1 = m_Player.FindAction("SelectSlot_1", throwIfNotFound: true);
            m_Player_SelectSlot_2 = m_Player.FindAction("SelectSlot_2", throwIfNotFound: true);
            m_Player_SelectSlot_3 = m_Player.FindAction("SelectSlot_3", throwIfNotFound: true);
            m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
            m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
            m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            m_Player_ActivateBuildScheme = m_Player.FindAction("ActivateBuildScheme", throwIfNotFound: true);
            m_Player_OpenBuildMenu = m_Player.FindAction("OpenBuildMenu", throwIfNotFound: true);
            m_Player_RotateTrapScheme = m_Player.FindAction("RotateTrapScheme", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Shoot;
        private readonly InputAction m_Player_Aim;
        private readonly InputAction m_Player_Build;
        private readonly InputAction m_Player_MouseMove;
        private readonly InputAction m_Player_SelectSlot_1;
        private readonly InputAction m_Player_SelectSlot_2;
        private readonly InputAction m_Player_SelectSlot_3;
        private readonly InputAction m_Player_Reload;
        private readonly InputAction m_Player_Run;
        private readonly InputAction m_Player_Crouch;
        private readonly InputAction m_Player_Interact;
        private readonly InputAction m_Player_ActivateBuildScheme;
        private readonly InputAction m_Player_OpenBuildMenu;
        private readonly InputAction m_Player_RotateTrapScheme;
        public struct PlayerActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
            public InputAction @Aim => m_Wrapper.m_Player_Aim;
            public InputAction @Build => m_Wrapper.m_Player_Build;
            public InputAction @MouseMove => m_Wrapper.m_Player_MouseMove;
            public InputAction @SelectSlot_1 => m_Wrapper.m_Player_SelectSlot_1;
            public InputAction @SelectSlot_2 => m_Wrapper.m_Player_SelectSlot_2;
            public InputAction @SelectSlot_3 => m_Wrapper.m_Player_SelectSlot_3;
            public InputAction @Reload => m_Wrapper.m_Player_Reload;
            public InputAction @Run => m_Wrapper.m_Player_Run;
            public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputAction @ActivateBuildScheme => m_Wrapper.m_Player_ActivateBuildScheme;
            public InputAction @OpenBuildMenu => m_Wrapper.m_Player_OpenBuildMenu;
            public InputAction @RotateTrapScheme => m_Wrapper.m_Player_RotateTrapScheme;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @MouseMove.started += instance.OnMouseMove;
                @MouseMove.performed += instance.OnMouseMove;
                @MouseMove.canceled += instance.OnMouseMove;
                @SelectSlot_1.started += instance.OnSelectSlot_1;
                @SelectSlot_1.performed += instance.OnSelectSlot_1;
                @SelectSlot_1.canceled += instance.OnSelectSlot_1;
                @SelectSlot_2.started += instance.OnSelectSlot_2;
                @SelectSlot_2.performed += instance.OnSelectSlot_2;
                @SelectSlot_2.canceled += instance.OnSelectSlot_2;
                @SelectSlot_3.started += instance.OnSelectSlot_3;
                @SelectSlot_3.performed += instance.OnSelectSlot_3;
                @SelectSlot_3.canceled += instance.OnSelectSlot_3;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @ActivateBuildScheme.started += instance.OnActivateBuildScheme;
                @ActivateBuildScheme.performed += instance.OnActivateBuildScheme;
                @ActivateBuildScheme.canceled += instance.OnActivateBuildScheme;
                @OpenBuildMenu.started += instance.OnOpenBuildMenu;
                @OpenBuildMenu.performed += instance.OnOpenBuildMenu;
                @OpenBuildMenu.canceled += instance.OnOpenBuildMenu;
                @RotateTrapScheme.started += instance.OnRotateTrapScheme;
                @RotateTrapScheme.performed += instance.OnRotateTrapScheme;
                @RotateTrapScheme.canceled += instance.OnRotateTrapScheme;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Shoot.started -= instance.OnShoot;
                @Shoot.performed -= instance.OnShoot;
                @Shoot.canceled -= instance.OnShoot;
                @Aim.started -= instance.OnAim;
                @Aim.performed -= instance.OnAim;
                @Aim.canceled -= instance.OnAim;
                @Build.started -= instance.OnBuild;
                @Build.performed -= instance.OnBuild;
                @Build.canceled -= instance.OnBuild;
                @MouseMove.started -= instance.OnMouseMove;
                @MouseMove.performed -= instance.OnMouseMove;
                @MouseMove.canceled -= instance.OnMouseMove;
                @SelectSlot_1.started -= instance.OnSelectSlot_1;
                @SelectSlot_1.performed -= instance.OnSelectSlot_1;
                @SelectSlot_1.canceled -= instance.OnSelectSlot_1;
                @SelectSlot_2.started -= instance.OnSelectSlot_2;
                @SelectSlot_2.performed -= instance.OnSelectSlot_2;
                @SelectSlot_2.canceled -= instance.OnSelectSlot_2;
                @SelectSlot_3.started -= instance.OnSelectSlot_3;
                @SelectSlot_3.performed -= instance.OnSelectSlot_3;
                @SelectSlot_3.canceled -= instance.OnSelectSlot_3;
                @Reload.started -= instance.OnReload;
                @Reload.performed -= instance.OnReload;
                @Reload.canceled -= instance.OnReload;
                @Run.started -= instance.OnRun;
                @Run.performed -= instance.OnRun;
                @Run.canceled -= instance.OnRun;
                @Crouch.started -= instance.OnCrouch;
                @Crouch.performed -= instance.OnCrouch;
                @Crouch.canceled -= instance.OnCrouch;
                @Interact.started -= instance.OnInteract;
                @Interact.performed -= instance.OnInteract;
                @Interact.canceled -= instance.OnInteract;
                @ActivateBuildScheme.started -= instance.OnActivateBuildScheme;
                @ActivateBuildScheme.performed -= instance.OnActivateBuildScheme;
                @ActivateBuildScheme.canceled -= instance.OnActivateBuildScheme;
                @OpenBuildMenu.started -= instance.OnOpenBuildMenu;
                @OpenBuildMenu.performed -= instance.OnOpenBuildMenu;
                @OpenBuildMenu.canceled -= instance.OnOpenBuildMenu;
                @RotateTrapScheme.started -= instance.OnRotateTrapScheme;
                @RotateTrapScheme.performed -= instance.OnRotateTrapScheme;
                @RotateTrapScheme.canceled -= instance.OnRotateTrapScheme;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard+Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnBuild(InputAction.CallbackContext context);
            void OnMouseMove(InputAction.CallbackContext context);
            void OnSelectSlot_1(InputAction.CallbackContext context);
            void OnSelectSlot_2(InputAction.CallbackContext context);
            void OnSelectSlot_3(InputAction.CallbackContext context);
            void OnReload(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnActivateBuildScheme(InputAction.CallbackContext context);
            void OnOpenBuildMenu(InputAction.CallbackContext context);
            void OnRotateTrapScheme(InputAction.CallbackContext context);
        }
    }
}
