using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data of where/what the player is looking, as well as several functionalities for shooting weapons.
/// </summary>
public class FPSCamera : MonoBehaviour
{
    private GameObject targetHit;

    /// <summary>
    /// function used for screen "kick". USeful for Flinching, recoil, and other effects.
    /// </summary>
    /// <param name="magnitude">force of the kick</param>
    /// <param name="vector">direction of the kick</param>
    public void Kick(float magnitude, Vector2 vector){

    }
}