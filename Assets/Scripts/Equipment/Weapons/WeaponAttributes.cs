using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TeamFPS/Weapons/Attributes", order = 1)]
public class WeaponAttributes : ScriptableObject{
    [Header("Damage per Second")]
    [SerializeField] private float rateOfFire; //AutoFire speed
    [SerializeField] private float damage;
    

    [Header("Ammunition")]
    [SerializeField] private float reloadSpeed; //in Seconds
    [SerializeField] [Range(1, 500)]private int magSize; 
    [SerializeField] [Range(0, 10)]private int ammoPoolLimit;

    /// <summary>Magnitude of recoil force.</summary>
    [Header("Recoil")]
    [SerializeField][Range(0, 5)]private float recoil;
    /// <summary> Left-Right deviation during recoil. </summary>
    [SerializeField][Range(0, 5)]private float recoilControl;
    // TODO: Change this to be character attribute, not weapon.
    /// <summary> Rate that camera returns to resting position </summary>
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
    public float ReloadSpeed => reloadSpeed;
    public int MagSize => magSize;
    public int AmmoReserveLimit => ammoPoolLimit;
    public float Recoil => recoil;
    public float RecoilControl => recoilControl;
    public float RecoilRecovery => recoilRecovery;
    public float HipAccuracy => hipAccuracy;
    public float AimAccuracy => aimAccuracy;
    public float Stability => stability;
    public float BloomRecoveryTime => bloomRecovery;
}