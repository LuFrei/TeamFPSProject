using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour{
    [Header("Damage per Second")]
    [SerializeField] private float rateOfFire; //AutoFire speed
    [SerializeField] private float damage;
    

    [Header("Ammunition")]
    [SerializeField] private float reloadSpeed; //in Seconds
    [SerializeField] private int magSize; 
    [SerializeField] private int ammoPoolLimit;

    [Header("Recoil")]
    public float recoil;
    public float recoilControl;


    [Header("Bloom")]
    public float bloomRecovery;
    public float stability; //how much is added to bloom per shot
    public float hipAccuracy; //hip-fire bloom
    [SerializeField] private float aimAccuracy; 

    public float RateOfFire /*convert from RPS to RPM*/{
        get => rateOfFire / 60f;
        set => rateOfFire = value * 60f;
    }
}