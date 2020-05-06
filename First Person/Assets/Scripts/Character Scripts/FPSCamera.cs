using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data of where/what the player is looking, as well as several functionalities for shooting weapons.
/// </summary>
public class FPSCamera : MonoBehaviour
{
    private Camera cam;
    private GameObject targetHit;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 centerPoint;

    public RaycastHit Hit => hit;
    void Awake()
    {
        cam = GetComponent<Camera>();
        centerPoint = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
    }

    void Update(){
        CastRay(out hit);
    }

    void CastRay(out RaycastHit hit) {
        ray = cam.ScreenPointToRay(centerPoint);
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