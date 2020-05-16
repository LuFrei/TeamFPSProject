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


    void Awake()
    {
        centerPoint = new Vector3(0.5f, 0.5f, 0);
        cam = GetComponent<Camera>();
        player = GetComponentInParent<FPSCharacterController>();
    }

    void Update(){
        CastRay(out hit);
        player.OnHand.RayDirection = ray.direction;
    }

    private void CastRay(out RaycastHit hit) {
        ray = cam.ViewportPointToRay(centerPoint);
        if(Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        } else {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }

    public Quaternion GenerateRandomDeviation(float magnitude) {
        Quaternion baseDir = Quaternion.LookRotation(ray.direction);
        float xDeviation = Random.Range(-magnitude, magnitude);
        float yDeviation = Random.Range(-magnitude, magnitude);
        baseDir *= Quaternion.AngleAxis(yDeviation, Vector3.right);
        baseDir *= Quaternion.AngleAxis(xDeviation, Vector3.up);
        return baseDir;
    }
    public void Kick(float magnitude, Vector2 vector){

    }
}