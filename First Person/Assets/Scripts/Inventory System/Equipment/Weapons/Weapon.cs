using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon: UsableItem
{
    [Flags] public enum FireMode { Auto = 0, Burst = 1, Single = 2 }
    public FireMode currentMode;
    public int burstSize = 3; //if applicable

    [Header("Dependencies")]
    public FPSCamera FPSCam;
    public WeaponAttributes attributes;
    [SerializeField] private GameObject bullet;
    
    private AccuracySpread accuracy = new AccuracySpread();
    private Ammo ammunition;

    //Chamber and Trigger
    private bool isLoaded = true; //Ready to shoot the next bullet
    private bool isReceivingInput; //Am I recieving input?
    private bool isBusy = false; //Am I ready for the next input?

    private float loadBuffer = 1;

    private int activeSequence = 0;//Keep track of burst cycle

    //Aiming
    private float aimingSpeed;
    private float walkingSpeed;
    private float aimZoom = 1.2f;

    public override AccuracySpread Accuracy => accuracy;
    public override Ammo Ammo => ammunition;


    private void Awake() {
        accuracy.SetNewBloomSource(attributes.HipAccuracy);
        ammunition = new Ammo(attributes.MagSize);    
    }

    private void Update() {
        if(!isBusy) {
            FPSCam.ResetView(attributes.RecoilRecovery);
        }
        accuracy.RecoverBloom(attributes.BloomRecoveryTime);
    }



    private void Shoot(float kickMagnitude) {
        Instantiate(bullet, FPSCam.Ray.origin, FPSCam.GenerateRandomDeviation(accuracy.Bloom));
        FPSCam.Kick(kickMagnitude, attributes.RecoilControl);
        accuracy.AddBloom(attributes.Stability);
        ammunition.ExpendBullet();
        Debug.Log("I went bang!");
        loadBuffer = 0;
        isLoaded = false;
        StartCoroutine(CycleShot());
    } 
    private IEnumerator CycleShot() {
        while(loadBuffer < 1) {
            loadBuffer += Time.deltaTime * attributes.RateOfFire;
            yield return null; 
        }
        isLoaded = true;
        Debug.Log("Done Cycling");
    }



    #region Aiming Functions
    void ToAimDownSight(float zoomMultiplier) {
        FPSCam.Zoom(zoomMultiplier);
        accuracy.SetNewBloomSource(attributes.AimAccuracy);
    }

    void ToHipfire() {
        FPSCam.Zoom(1);
        accuracy.SetNewBloomSource(attributes.HipAccuracy);
    }
    #endregion

    #region FireModes
    private IEnumerator AutoFire() {
        isBusy = true;
        float recoilDamper= attributes.Recoil;
        while(isReceivingInput) {
            if(isLoaded) {
                Shoot(recoilDamper);
                recoilDamper = Mathf.Lerp(recoilDamper, 0, 0.1f);
            }
            yield return null;
        }
        isBusy = false;
    }
    private void SingleFire() {
        if(isLoaded) {
            Shoot(attributes.Recoil);
        }
    }
    private IEnumerator BurstFire() {
        isBusy = true;
        while(activeSequence < burstSize){
            if(isLoaded) {
                Shoot(attributes.Recoil);
                activeSequence++;
            }
            yield return null;
        }
        isBusy = false;
        activeSequence = 0;
    }
    #endregion

    #region UsableItem Methods
    public override void OnPrimaryActionStart() { 
        isReceivingInput = true;
        if(!isBusy) {
            switch(currentMode) {
                case FireMode.Auto:
                    Debug.Log("Shooting Auto");
                    StartCoroutine(AutoFire());
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
    public override void OnPrimaryActionEnd() {
        isReceivingInput = false;
    }

    public override void OnSecondaryActionStart() {
        ToAimDownSight(aimZoom);
    }
    public override void OnSecondaryActionEnd() {
        ToHipfire();
    }
    public override void ChangeMode() {
        if(currentMode < FireMode.Single) {
            currentMode++;
        } else {
            currentMode = FireMode.Auto;
        }

        Debug.Log(currentMode);
    }
    #endregion
}