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

    void CastRay(out RaycastHit hit) {
        ray = cam.ViewportPointToRay(centerPoint);
        if(Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
        } else {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }


    /// <summary>
    /// function used for screen "kick". USeful for Flinching, recoil, and other effects.
    /// </summary>
    /// <param name="magnitude">force of the kick</param>
    /// <param name="vector">direction of the kick</param>
    public void Kick(float magnitude, Vector2 vector){

    }
}