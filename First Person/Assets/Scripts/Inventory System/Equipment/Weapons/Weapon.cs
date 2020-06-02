using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: UsableItem
{
    [Flags] public enum FireMode { Auto = 0, Burst = 1, Single = 2 }
    public FireMode currentMode;

    [Header("Dependencies")]
    public FPSCamera FPSCam;

    #region attributes
    [Header("Weapon Attributes")]
    [SerializeField] private float rateOfFire; //AutoFire speed
    [SerializeField] private float damage;
    [SerializeField] private int burstSize = 3; //if applicable

    [SerializeField] private float reloadSpeed; //in Seconds
    [SerializeField] private int magSize; //Just in case... "0" will be treated as infinite for both mag and pool size (for possible in-game match editing)
    [SerializeField] private int ammoPoolLimit;

    [SerializeField] private float recoil;
    [SerializeField] private float recoilControl;
    [SerializeField] private float hipAccuracy; //hip-fire bloom
    [SerializeField] private float aimAccuracy;
    #endregion


    //
    private float hipMaxAccuracy;
    private float hipMinAccuracy;


    //Bullet info
    [SerializeField] private GameObject bullet;

    //Chamber and Trigger
    private bool loaded = true; //Ready to shoot the next bullet
    private bool active; //Am I recieving input
    private bool ready = true; //Ready for the next input?

    private float loadBuffer = 1;

    //Magazine and Ammo
    private int currentMagValue;
    private int currentReserve;
    private float reloadProgress;

    private int activeSequence = 0;//Keep track of burst cycle, and possible stat tracking


    public float RateOfFire { get { return rateOfFire * 60f; } } //returns in RPM

    private void Update() {
        //Main
        if(active && ready) {
            switch(currentMode) {
                case FireMode.Auto:
                    Debug.Log("Shooting Auto");
                    AutoFire();
                    break;
                case FireMode.Burst:
                    Debug.Log("Shooting Burst");
                    StartCoroutine(BurstFire());
                    break;
                case FireMode.Single:
                    Debug.Log("Shooting Single");
                    SingleFire();
                    break;
            }
        }
    }



    private void Shoot() {
        Instantiate(bullet, FPSCam.Ray.origin, FPSCam.GenerateRandomDeviation(hipAccuracy));
        FPSCam.Kick(recoil, recoilControl);
        Debug.Log("I went bang!");
        loadBuffer = 0;
        loaded = false;
        StartCoroutine(CycleShot());
    } 
    
    private IEnumerator CycleShot() {
        while(loadBuffer < 1) {
            loadBuffer += Time.deltaTime * rateOfFire;
            yield return null; 
        }
        loaded = true;
        Debug.Log("Done Cycling");
    }



    #region FireModes
    private void AutoFire() {
        if(loaded) {
            Shoot();
        }
    }
    private void SingleFire() {
        ready = false;
        if(loaded) {
            Shoot();
        }
    }
    private IEnumerator BurstFire() {
        active = false;
        ready = false;
        while(activeSequence < burstSize){
            if(loaded) {
                Shoot();
                activeSequence++;
            }
            yield return null;
        }
        ready = true;
        activeSequence = 0;
    }
    #endregion

    public override void OnPrimaryActionStart() { 
        active = true;
    }

    //Restart parameters
    public override void OnPrimaryActionEnd() {
        active = false;
        if(currentMode == FireMode.Single)
            ready = true;
    }

    public override void ChangeMode() {
        if(currentMode < FireMode.Single) {
            currentMode++;
        } else {
            currentMode = FireMode.Auto;
        }

        Debug.Log(currentMode);
    }
}