using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TWG.Character;
using TWG.CoreSystems;
// TODO: Look to see if we can obscure this dependency.
using TWG.Equipment;

namespace TWG.Player {
public class InputHandler: MonoBehaviour {

    [SerializeField] private Character.Controller player;
    [SerializeField] private GameManager gm;
    [SerializeField] private PlayerInput input;
    //private InputManager inputAsset;

    public bool isAiming = false;

    private void Awake() {
        //inputAsset = new InputManager();
        input = GetComponent<PlayerInput>();
    }




    void OnChangeMode() {
        player.Hand.CurrentRightEquipped.ChangeMode();
    }

    void OnJump() {
        player.Jump();
    }

    void OnToggleMenu() {
        if(gm.AccessMenu()) {
            input.SwitchCurrentActionMap("UI");
        } else {
            input.SwitchCurrentActionMap("Player");
        }
    }

    void OnMove(InputValue value) {
        player.MoveVector = value.Get<Vector2>();
    }

    void OnLook(InputValue value) {
        player.Head.Turn(value.Get<Vector2>());
    }

    void OnShoot(InputValue value) {
        if(value.isPressed) {
            player.Hand.CurrentRightEquipped.PrimaryActionStart();
        } else if(!value.isPressed) {
            player.Hand.CurrentRightEquipped.PrimaryActionEnd();
        }
    }

    //stancemodes
    void OnCrouch(InputValue value) {
        //"Hold" logic
        if(value.isPressed) {
            player.ToStance(Stance.Crouch);
        } else if(!value.isPressed && player.currentStance == Stance.Crouch) {
            player.ToStance(Stance.Stand);
        }
    }

    void OnProne(InputValue value) {
        //"Toggle" logic
        if(value.isPressed && player.currentStance == Stance.Prone) {
            player.ToStance(Stance.Stand);
        } else if(value.isPressed) {
            player.ToStance(Stance.Prone);
        }
    }

    void OnAim(InputValue value) {
        //"Toggle" logic
        if(value.isPressed && !isAiming) {
            isAiming = true;
            player.Hand.CurrentRightEquipped.SecondaryActionStart();
        } else if(value.isPressed) {
            isAiming = false;
            player.Hand.CurrentRightEquipped.SecondaryActionEnd();
        }

    }

    void OnSwapToPrimary() {
        player.EquipItem(0);
    }

    void OnSwapToSecondary() {
        player.EquipItem(1);
    }

    void OnReload() {
        player.Hand.CurrentRightEquipped.Reload();
    }




    // TODO: Look if this is still needed/why it was used before.
    //void OnEnable() {
    //    inputAsset.Enable();
    //}
    //void OnDisable() {
    //    inputAsset.Disable();
    //}
}
}
