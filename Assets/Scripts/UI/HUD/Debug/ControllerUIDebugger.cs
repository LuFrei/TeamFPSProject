using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

namespace TWG.HUD.Debugger {
public class ControllerUIDebugger: MonoBehaviour {
    [SerializeField]
    private GameObject
        up, right, down, left,
        triangle, circle, cross, square,
        L1, L2, R1, R2,
        touchpad, share, option;

    //void FixedUpdate() {
    //    var gamepad = Gamepad.current;
    //    Debug.Log("AH!");
    //    Debug.Log("Found: " + gamepad.name);


    //    if(gamepad.rightTrigger.wasPressedThisFrame) {

    //        // 'Use' code here
    //    }

    //    Vector2 move = gamepad.leftStick.ReadValue();
    //    // 'Move' code here
    //}
}
}