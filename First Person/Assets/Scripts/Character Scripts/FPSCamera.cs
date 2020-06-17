using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data of where/what the player is looking, as well as several functionalities for shooting weapons.
/// </summary>
public class FPSCamera: MonoBehaviour
{
    //Dependencies
    private Camera cam;
    [SerializeField] private Transform body;

    [Header("Camera Control Settings")]
    [SerializeField] private float sensitivity = 5;
    [SerializeField] private float maxLookAngle = 90;
    [SerializeField] private float minLookAngle = -90;
    [SerializeField] private float baseFieldOfView;

    private Vector2 lookAngle; //Total angle inclusing things like camera kick
    private Vector2 mouseLookAngle; //records the angle the camera should be exclusively from mouse input


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

            mouseLookAngle.y = Mathf.Clamp(mouseLookAngle.y, minLookAngle, maxLookAngle);
            lookAngle.y = Mathf.Clamp(lookAngle.y, minLookAngle, maxLookAngle);

        }
    }
    public Vector2 LookOffsetVector {
        set {
            lookAngle += value;
        }
    }
    public Camera Camera => cam;



    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void Start() {
        baseFieldOfView = cam.fieldOfView;
    }
    private void FixedUpdate(){
        Look(lookAngle);
        CastRay(out hit);
    }


    public void Look(Vector2 angle) {
        transform.localRotation = Quaternion.Euler(-angle.y, 0, 0); //y inverted as it seems that up is -x
        body.transform.localRotation = Quaternion.Euler(0, angle.x, 0);  //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)
    }

    private void CastRay(out RaycastHit hit) {
        ray = cam.ViewportPointToRay(centerPoint);
        if(Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        } else {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }

    public void ResetView(float rate) {
        lookAngle.y = Mathf.MoveTowards(lookAngle.y, mouseLookAngle.y, rate);
    }

    public Quaternion GenerateRandomDeviation(float maxMagnitude) {
        Quaternion newDirection = Quaternion.LookRotation(ray.direction);
        float angle = Random.Range(0, 360);
        float magnitude = Random.Range(0, maxMagnitude);
        newDirection *= Quaternion.AngleAxis(angle, Vector3.forward);
        newDirection *= Quaternion.AngleAxis(magnitude, Vector3.right);
        return newDirection;
    }

    public void Kick(float magnitude, float hozOffset) {
        Vector2 kickVector = Vector2.up * magnitude;
        kickVector.x = Random.Range(-hozOffset, hozOffset);
        lookAngle += kickVector;
    }

    public void Zoom(float multiplier) {
        cam.fieldOfView = baseFieldOfView / multiplier;
    }
}