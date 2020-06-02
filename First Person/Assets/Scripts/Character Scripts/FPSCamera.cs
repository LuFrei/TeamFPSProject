using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data of where/what the player is looking, as well as several functionalities for shooting weapons.
/// </summary>
public class FPSCamera : MonoBehaviour
{
    private Camera cam;
    [SerializeField]private FPSCharacterController player;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 centerPoint;

    public Ray Ray => ray;
    public RaycastHit Hit => hit;


    private void Awake()
    {
        centerPoint = new Vector3(0.5f, 0.5f, 0);
        cam = GetComponent<Camera>();
        player = GetComponentInParent<FPSCharacterController>();
    }

    private void Update(){
        CastRay(out hit);
    }

     
    private void CastRay(out RaycastHit hit) {
        ray = cam.ViewportPointToRay(centerPoint);
        if(Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        } else {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }


    public Quaternion GenerateRandomDeviation(float maxMagnitude) {
        Quaternion newDirection = Quaternion.LookRotation(ray.direction);
        float angle = Random.Range(0, 360);
        float magnitude = Random.Range(0, maxMagnitude);
        newDirection *= Quaternion.AngleAxis(angle, Vector3.forward);
        newDirection *= Quaternion.AngleAxis(magnitude, Vector3.right);
        return newDirection;
    }

    public void Kick(float magnitude, float hozDirection) {
        Vector2 kickVector = Vector2.up;
        kickVector.x = Random.Range(-hozDirection, hozDirection) / 100;
        player.LookOffsetVector = kickVector * magnitude;
    }


}