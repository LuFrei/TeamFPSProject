using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour{
    [Header("Weapon Attributes")]
    [SerializeField] private float rateOfFire; //AutoFire speed
    [SerializeField] private float damage;
    [SerializeField] private int burstSize = 3; //if applicable

    [SerializeField] private float reloadSpeed; //in Seconds
    [SerializeField] private int magSize; //Just in case... "0" will be treated as infinite for both mag and pool size (for possible in-game match editing)
    [SerializeField] private int ammoPoolLimit;

    [SerializeField] private float recoil;
    [SerializeField] private float hipAccuracy; //hip-fire bloom
    [SerializeField] private float aimAccuracy; //ADS bloom (NOTE: This should not be set high. Shots should still land REASNOABLY close to aimed location

}