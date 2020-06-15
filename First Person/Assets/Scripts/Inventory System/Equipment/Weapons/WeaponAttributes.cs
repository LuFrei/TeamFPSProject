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
    [SerializeField][Range(0, 5)]private float recoil;
    [SerializeField][Range(0, 5)]private float recoilControl;
    [SerializeField][Range(0.15f, 1)]private float recoilRecovery;

    [Header("Accuracy")]
    [SerializeField][Range(25, 0)] private float hipAccuracy;
    [SerializeField][Range(5, 0)] private float aimAccuracy;
    [SerializeField][Range(4, 0)] private float stability; //how much is added to bloom per shot
    [SerializeField][Range(0.5f, 0.1f)] public float bloomRecovery;
    

    public float RateOfFire /*convert from RPS to RPM*/{
        get => rateOfFire / 60f;
        set => rateOfFire = value * 60f;
    }
    public float Damage => damage;

    public float Recoil => recoil;
    public float RecoilControl => recoilControl;
    public float RecoilRecovery => recoilRecovery;
    public float HipAccuracy => hipAccuracy;
    public float AimAccureacy => aimAccuracy;
    public float Stability => stability;
    public float BloomRecoveryTime => bloomRecovery;
}