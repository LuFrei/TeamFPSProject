using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookTest : MonoBehaviour
{
    private Vector2 aimVector;
    private Vector2 aimAngle;
    private Vector2 offsetAngle;
    [SerializeField]private float recoverSpeed;
    [SerializeField]private float recoverVelocity;
    private bool isAngleOffset;
    [SerializeField] private Transform body;

    public Vector2 AimLook { 
        set { 
            aimVector = value * Time.deltaTime;
            aimAngle += aimVector;
        }
    }
    public Vector2 OffsetLook {
        set {
            aimVector = value * Time.deltaTime;
            offsetAngle += value * Time.deltaTime;
            isAngleOffset = true;
        }
    }


    private void Update() {
        if(isAngleOffset) {
            ResetAim();
        }
        Look(aimVector);
    }

    private void Look(Vector2 lookVector) {
        body.Rotate(Vector3.up, lookVector.x);
        transform.Rotate(Vector3.right, -lookVector.y);
    }

    private void Kick(Vector2 kickVector) {
        OffsetLook = kickVector;
        Look(kickVector);
    }

    private void ResetAim() {
        Debug.Log("Reseting aim");
        aimVector.y = Mathf.SmoothDamp(offsetAngle.y, aimAngle.y, ref recoverVelocity, recoverSpeed);

        offsetAngle.y -= aimVector.y;
        if(offsetAngle.y == aimAngle.y) {
            isAngleOffset = false;
        }

    }

    private void OnShoot() {
        Kick(new Vector2(0.5f, 3f));
    }

    private void OnLook(InputValue value) {
        Debug.Log("called OnLook");
        AimLook = value.Get<Vector2>();
    }
}
