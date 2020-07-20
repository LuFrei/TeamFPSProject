// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2ef9ffc8-61b3-4b49-8a9e-c6b459a6a175"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a6184859-d14d-4ee6-a8ba-01373d2320bb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e13c8b3a-5f3a-4837-b53a-20b3d96614dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Stance"",
                    ""type"": ""Button"",
                    ""id"": ""2987c0f6-fff0-4e75-9e17-a6f3222a77e0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5abfcb1b-bb6c-48a5-b79a-80b36f3d6ba0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Prone"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da92b252-d766-40be-b350-72cd0b6fde74"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""153995f2-392f-4147-be8a-85a1a635aa50"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""0b4486d7-2b3e-4406-b854-1c81d356041f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""9e82b396-7087-49c9-b7c5-6a846a0eb71f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""09a9fbca-cec8-4884-a11e-b56d88a30b6b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""9949efd4-03f2-46ae-a480-7fadaea6034a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""8f6efccf-7204-4b10-a069-4d6e7b35d01e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Mode"",
                    ""type"": ""Button"",
                    ""id"": ""8e02380e-9d99-4c98-8be6-45cc8b54a723"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap to Primary Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""6cea371e-124f-423c-872d-a0fb8fd8ed90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap to Secondary Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""c9ae786b-2f7e-4af5-80cd-8620d1c3c4dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap to Knife"",
                    ""type"": ""Button"",
                    ""id"": ""f96a4186-367a-469c-b698-eee25301bb35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap to Grenade"",
                    ""type"": ""Button"",
                    ""id"": ""ffb5725f-0b9d-4ae2-964c-93317e31caa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap to Utility"",
                    ""type"": ""Button"",
                    ""id"": ""89857c0d-19cb-497c-8892-f5118fd8294f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Swap to Equipment"",
                    ""type"": ""Button"",
                    ""id"": ""f23d7dec-e566-4ee5-830d-a210ff655f90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""caaec5c3-1e04-4980-bfde-6703d2e8e52c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3c922abc-4918-4e52-8e22-c2e96b4bbbc1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1f447d21-d20e-48fe-a487-e14e277a4402"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3664de04-c728-4e6d-980e-b797cdc29aca"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c613894e-f371-4ac4-ab05-fa640aa58c38"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6670961d-b210-4153-b949-1db660e44582"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0776ff4-7402-4fab-8df8-5d1335993085"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73823106-0ceb-402b-9354-16062a8de184"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dca5299-b875-4b70-94fe-e64d668a8935"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Change Stance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5eb22c8a-b104-4e48-9d7b-e8826841dc84"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Change Stance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b31b92b-b896-44d7-bf77-9bf6d6cea6e9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63f6b42a-542d-4fd0-8a5c-fb39403e0780"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4011a7e4-d440-4bb8-b8c6-f181bf5453d0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffeccf85-27a8-4825-8a39-cf89ffb5387a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad0f51de-8374-4735-97d9-45fb6e6d4f03"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48771399-50a2-40b3-862b-0a971832f192"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42f115c8-98d7-4aa6-b490-3672de1a76c2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ce8455f-1542-4e93-9b55-c737606e4f6e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""057af393-7dc6-4212-88ba-85303bbbc77e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cef61bcc-967c-47a1-b63f-ccb4c886668d"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb29683f-05de-4789-808f-49ac835d3889"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f31a049-fd73-4499-867b-3f15ad66c88d"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Change Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88d9e316-ba77-4075-8882-cfc7618178c8"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Change Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be1b5dd5-263a-4fa6-b0a2-05ce98ddd00f"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b2695a4-28cd-4047-87e4-26338b531dbb"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Prone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""251dda14-aa9d-4b06-b22b-c01fc5595928"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap to Primary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ce5ac2a-1ad8-41f8-a6f4-35e4f4b160d2"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap to Knife"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46b6f4d5-e941-46dd-86eb-6d030e73cb8c"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap to Grenade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97d74e93-9f1f-453b-b64c-c3f0737a6b03"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap to Utility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa76c2d2-32b2-4a77-b7f7-e4f50568986f"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap to Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e22f5868-f739-4602-bcda-0cd449c2ea0b"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap to Secondary Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""General"",
            ""id"": ""a27d1d6e-648e-4ad2-8e02-b2710072728c"",
            ""actions"": [
                {
                    ""name"": ""Open Menu"",
                    ""type"": ""Button"",
                    ""id"": ""dd100e8c-bfb5-4e18-9b1e-75a94bbace41"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f8acb23-bde3-4f22-be27-a39a73d4991e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Open Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49bdd5f1-5e1b-4bb2-b256-411addc4a467"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Open Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS4"",
            ""bindingGroup"": ""PS4"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_ChangeStance = m_Player.FindAction("Change Stance", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Prone = m_Player.FindAction("Prone", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_Melee = m_Player.FindAction("Melee", throwIfNotFound: true);
        m_Player_ChangeMode = m_Player.FindAction("Change Mode", throwIfNotFound: true);
        m_Player_SwaptoPrimaryWeapon = m_Player.FindAction("Swap to Primary Weapon", throwIfNotFound: true);
        m_Player_SwaptoSecondaryWeapon = m_Player.FindAction("Swap to Secondary Weapon", throwIfNotFound: true);
        m_Player_SwaptoKnife = m_Player.FindAction("Swap to Knife", throwIfNotFound: true);
        m_Player_SwaptoGrenade = m_Player.FindAction("Swap to Grenade", throwIfNotFound: true);
        m_Player_SwaptoUtility = m_Player.FindAction("Swap to Utility", throwIfNotFound: true);
        m_Player_SwaptoEquipment = m_Player.FindAction("Swap to Equipment", throwIfNotFound: true);
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_OpenMenu = m_General.FindAction("Open Menu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_ChangeStance;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Prone;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_Melee;
    private readonly InputAction m_Player_ChangeMode;
    private readonly InputAction m_Player_SwaptoPrimaryWeapon;
    private readonly InputAction m_Player_SwaptoSecondaryWeapon;
    private readonly InputAction m_Player_SwaptoKnife;
    private readonly InputAction m_Player_SwaptoGrenade;
    private readonly InputAction m_Player_SwaptoUtility;
    private readonly InputAction m_Player_SwaptoEquipment;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @ChangeStance => m_Wrapper.m_Player_ChangeStance;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Prone => m_Wrapper.m_Player_Prone;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @Melee => m_Wrapper.m_Player_Melee;
        public InputAction @ChangeMode => m_Wrapper.m_Player_ChangeMode;
        public InputAction @SwaptoPrimaryWeapon => m_Wrapper.m_Player_SwaptoPrimaryWeapon;
        public InputAction @SwaptoSecondaryWeapon => m_Wrapper.m_Player_SwaptoSecondaryWeapon;
        public InputAction @SwaptoKnife => m_Wrapper.m_Player_SwaptoKnife;
        public InputAction @SwaptoGrenade => m_Wrapper.m_Player_SwaptoGrenade;
        public InputAction @SwaptoUtility => m_Wrapper.m_Player_SwaptoUtility;
        public InputAction @SwaptoEquipment => m_Wrapper.m_Player_SwaptoEquipment;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @ChangeStance.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeStance;
                @ChangeStance.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeStance;
                @ChangeStance.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeStance;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Prone.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnProne;
                @Prone.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnProne;
                @Prone.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnProne;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Melee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @ChangeMode.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeMode;
                @ChangeMode.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeMode;
                @ChangeMode.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeMode;
                @SwaptoPrimaryWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoPrimaryWeapon;
                @SwaptoPrimaryWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoPrimaryWeapon;
                @SwaptoPrimaryWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoPrimaryWeapon;
                @SwaptoSecondaryWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoSecondaryWeapon;
                @SwaptoSecondaryWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoSecondaryWeapon;
                @SwaptoSecondaryWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoSecondaryWeapon;
                @SwaptoKnife.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoKnife;
                @SwaptoKnife.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoKnife;
                @SwaptoKnife.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoKnife;
                @SwaptoGrenade.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoGrenade;
                @SwaptoGrenade.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoGrenade;
                @SwaptoGrenade.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoGrenade;
                @SwaptoUtility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoUtility;
                @SwaptoUtility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoUtility;
                @SwaptoUtility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoUtility;
                @SwaptoEquipment.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoEquipment;
                @SwaptoEquipment.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoEquipment;
                @SwaptoEquipment.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwaptoEquipment;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @ChangeStance.started += instance.OnChangeStance;
                @ChangeStance.performed += instance.OnChangeStance;
                @ChangeStance.canceled += instance.OnChangeStance;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Prone.started += instance.OnProne;
                @Prone.performed += instance.OnProne;
                @Prone.canceled += instance.OnProne;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @ChangeMode.started += instance.OnChangeMode;
                @ChangeMode.performed += instance.OnChangeMode;
                @ChangeMode.canceled += instance.OnChangeMode;
                @SwaptoPrimaryWeapon.started += instance.OnSwaptoPrimaryWeapon;
                @SwaptoPrimaryWeapon.performed += instance.OnSwaptoPrimaryWeapon;
                @SwaptoPrimaryWeapon.canceled += instance.OnSwaptoPrimaryWeapon;
                @SwaptoSecondaryWeapon.started += instance.OnSwaptoSecondaryWeapon;
                @SwaptoSecondaryWeapon.performed += instance.OnSwaptoSecondaryWeapon;
                @SwaptoSecondaryWeapon.canceled += instance.OnSwaptoSecondaryWeapon;
                @SwaptoKnife.started += instance.OnSwaptoKnife;
                @SwaptoKnife.performed += instance.OnSwaptoKnife;
                @SwaptoKnife.canceled += instance.OnSwaptoKnife;
                @SwaptoGrenade.started += instance.OnSwaptoGrenade;
                @SwaptoGrenade.performed += instance.OnSwaptoGrenade;
                @SwaptoGrenade.canceled += instance.OnSwaptoGrenade;
                @SwaptoUtility.started += instance.OnSwaptoUtility;
                @SwaptoUtility.performed += instance.OnSwaptoUtility;
                @SwaptoUtility.canceled += instance.OnSwaptoUtility;
                @SwaptoEquipment.started += instance.OnSwaptoEquipment;
                @SwaptoEquipment.performed += instance.OnSwaptoEquipment;
                @SwaptoEquipment.canceled += instance.OnSwaptoEquipment;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_OpenMenu;
    public struct GeneralActions
    {
        private @InputManager m_Wrapper;
        public GeneralActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenMenu => m_Wrapper.m_General_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @OpenMenu.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    private int m_PS4SchemeIndex = -1;
    public InputControlScheme PS4Scheme
    {
        get
        {
            if (m_PS4SchemeIndex == -1) m_PS4SchemeIndex = asset.FindControlSchemeIndex("PS4");
            return asset.controlSchemes[m_PS4SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnChangeStance(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnProne(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnChangeMode(InputAction.CallbackContext context);
        void OnSwaptoPrimaryWeapon(InputAction.CallbackContext context);
        void OnSwaptoSecondaryWeapon(InputAction.CallbackContext context);
        void OnSwaptoKnife(InputAction.CallbackContext context);
        void OnSwaptoGrenade(InputAction.CallbackContext context);
        void OnSwaptoUtility(InputAction.CallbackContext context);
        void OnSwaptoEquipment(InputAction.CallbackContext context);
    }
    public interface IGeneralActions
    {
        void OnOpenMenu(InputAction.CallbackContext context);
    }
}
