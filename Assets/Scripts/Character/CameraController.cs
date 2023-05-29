using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data of where/what the player is looking, as well as several functionalities for shooting weapons.
/// </summary>
namespace TWG.Character {
public class CameraController: MonoBehaviour {
    //Dependencies
    private Camera cam;
    [SerializeField] private Transform body;

    //This data should be coming from outside, via an input manager

    [Header("Camera Control Settings")]
    [SerializeField] private float sensitivity = 5;
    [SerializeField] private float maxVerticalAngle = 90;
    [SerializeField] private float minVerticalAngle = -90;
    [SerializeField] private float baseFieldOfView;


    //! things liek kick and camera shake should be effects applied to the camera from the outside.
    private Vector2 lookAngle; //Total angle including things like camera kick
    private Vector2 mouseLookAngle; //records the angle the camera should be exclusively from mouse input

    //!This can an external script
    //Center-screen ray Data 
    private Ray ray;
    private RaycastHit hit;
    private Vector3 centerPoint = new Vector3(0.5f, 0.5f, 0);

    public Ray Ray => ray;
    public RaycastHit Hit => hit;


    public Vector2 LookVector {
        set {
            Vector2 vector = value * Time.deltaTime * sensitivity;
            mouseLookAngle += vector;
            lookAngle += vector;

            mouseLookAngle.y = Mathf.Clamp(mouseLookAngle.y, minVerticalAngle, maxVerticalAngle);
            lookAngle.y = Mathf.Clamp(lookAngle.y, minVerticalAngle, maxVerticalAngle);
        }
    }

    public Vector2 LookOffsetVector {
        set {
            lookAngle += value;
        }
    }
    public Camera Camera => cam;



    private void Awake() {
        cam = GetComponent<Camera>();
    }
    private void Start() {
        baseFieldOfView = cam.fieldOfView;
    }
    private void FixedUpdate() {
        // TODO: Can probably move Turn out of here and into an event.
        Turn(lookAngle);
        CastRay(out hit);
    }


    public void Turn(Vector2 angle) {
        //y inverted as it seems that up is -x
        transform.localRotation = Quaternion.Euler(-angle.y, 0, 0);
        //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)
        body.localRotation = Quaternion.Euler(0, angle.x, 0);  
    }

    private void CastRay(out RaycastHit hit) {
        ray = cam.ViewportPointToRay(centerPoint);
        if(Physics.Raycast(ray, out hit)) {
            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        } else {
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }

    public void ResetView(float rate) {
        lookAngle.y = Mathf.MoveTowards(lookAngle.y, mouseLookAngle.y, rate);
    }

    public void Flinch(float magnitude, float hozOffset) {
        Vector2 kickVector = Vector2.up * magnitude;
        kickVector.x = Random.Range(-hozOffset, hozOffset);
        lookAngle += kickVector;
    }

    public void Zoom(float multiplier) {
        cam.fieldOfView = baseFieldOfView / multiplier;
    }
}
}