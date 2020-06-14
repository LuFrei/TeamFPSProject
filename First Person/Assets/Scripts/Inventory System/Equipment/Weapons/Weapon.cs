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


    //Bullet info
    [SerializeField] private GameObject bullet;

    //Chamber and Trigger
    private bool loaded = true; //Ready to shoot the next bullet
    private bool active; //Am I recieving input?
    private bool ready = true; //Am I ready for the next input?

    private float loadBuffer = 1;

    //Magazine and Ammo
    private int currentMagValue;
    private int currentReserve;
    private float reloadProgress;

    private int activeSequence = 0;//Keep track of burst cycle

    //Bloom & Accuracy
    private float currentBloom;
    private float baseBloom;
    private float bloomRestoreVelocity;

    public override float Bloom {
        get => currentBloom;
        set => SetBaseBloom(value);
    }
     

    private void Awake() {
        baseBloom = attributes.hipAccuracy;
    }
    
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

        RecoverBloom();
    }



    private void Shoot() {
        Instantiate(bullet, FPSCam.Ray.origin, FPSCam.GenerateRandomDeviation(currentBloom));
        FPSCam.Kick(attributes.recoil, attributes.recoilControl);
        AddBloom(attributes.stability);
        Debug.Log("I went bang!");
        loadBuffer = 0;
        loaded = false;
        StartCoroutine(CycleShot());
    } 
    
    private IEnumerator CycleShot() {
        while(loadBuffer < 1) {
            loadBuffer += Time.deltaTime * attributes.RateOfFire;
            yield return null; 
        }
        loaded = true;
        Debug.Log("Done Cycling");
    }

    #region Bloom & Accuracy Functions
    private void AddBloom(float value) {
        currentBloom += value;
    }
    private void RecoverBloom() {
        currentBloom = Mathf.SmoothDamp(currentBloom, baseBloom, ref bloomRestoreVelocity, attributes.bloomRecovery);
    }
    private void SetBaseBloom(float modifier) {
        baseBloom = attributes.hipAccuracy * modifier;
    }


    #endregion

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

    #region UsableItem Methods
    public override void OnPrimaryActionStart() { 
        active = true;
    }
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
    #endregion
}