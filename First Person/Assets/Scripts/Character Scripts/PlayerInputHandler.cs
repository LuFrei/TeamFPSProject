﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField]private FPSCharacterController player;
    [SerializeField]private GameManager gm;
    private InputManager input;

     

    // Start is called before the first frame update
    void Awake() {
        input = new InputManager();

        //input.Player.Look.performed += ctx => player.LookVector = ctx.ReadValue<Vector2>();
        input.Player.Jump.performed += ctx => player.Jump();
        input.Player.Shoot.started += ctx => player.OnHand.OnPrimaryActionStart();
        input.Player.Shoot.canceled += ctx => player.OnHand.OnPrimaryActionEnd(); 
        input.Player.ChangeMode.performed += ctx => player.OnHand.ChangeMode();

        input.General.OpenMenu.performed += ctx => gm.ChangeGameState();
    }

    void OnMove(InputValue value) {
        player.MoveVector = value.Get<Vector2>(); 
    }

    void OnLook(InputValue value) {
        player.LookVector = value.Get<Vector2>();
    }

    //stancemodes
    void OnCrouch(InputValue value) {
        //"Hold" logic
        Debug.Log(value.isPressed);
        if(value.isPressed) {
            player.ToStance(Stance.Crouch);
        } else if(!value.isPressed && player.currentStance == Stance.Crouch) {
            player.ToStance(Stance.Stand);
        }
    }

    void OnProne(InputValue value) {
        //"Toggle" logic
        Debug.Log("OnProne running");
        if(value.isPressed && player.currentStance == Stance.Prone) { 
            player.ToStance(Stance.Stand);
        } else if(value.isPressed) {
            player.ToStance(Stance.Prone);
        }
    }

    

    #region Enable/Disable
    void OnEnable() {
        input.Enable();
    }
     
    void OnDisable() {
        input.Disable();
    }
    #endregion
}
