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
    private bool isLoaded = true; //Ready to shoot the next bullet
    private bool isReceivingInput; //Am I recieving input?
    private bool isBusy = false; //Am I ready for the next input?

    private float loadBuffer = 1;

    //Magazine and Ammo
    private int currentMagValue;
    private int currentReserve;
    private float reloadProgress;

    private int activeSequence = 0;//Keep track of burst cycle

    //Bloom & Accuracy
    [SerializeField]private float currentBloom;
    [SerializeField]private float baseBloom;

    public override float Bloom {
        get => currentBloom;
        set => SetBaseBloom(value);
    }
     

    private void Awake() {
        baseBloom = attributes.hipAccuracy;
    }
    private void Update() {
        if(!isBusy) {
            RecoverBloom();
            FPSCam.ResetView(attributes.accuracyRecoveryRate);
        }
    }



    private void Shoot() {
        Instantiate(bullet, FPSCam.Ray.origin, FPSCam.GenerateRandomDeviation(currentBloom));
        FPSCam.Kick(attributes.recoil, attributes.recoilControl);
        AddBloom(attributes.stability);
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

    #region Bloom & Accuracy Functions
    private void AddBloom(float value) {
        currentBloom += value;
    }
    private void RecoverBloom() {
        currentBloom = Mathf.MoveTowards(currentBloom, baseBloom, attributes.accuracyRecoveryRate);
    }
    private void SetBaseBloom(float modifier) {
        baseBloom = attributes.hipAccuracy * modifier;
    }


    #endregion

    #region FireModes
    private IEnumerator AutoFire() {
        isBusy = true;
        while(isReceivingInput) {
            if(isLoaded) {
                Shoot();
            }
            yield return null;
        }
        isBusy = false;
    }
    private void SingleFire() {
        if(isLoaded) {
            Shoot();
        }
    }
    private IEnumerator BurstFire() {
        isBusy = true;
        while(activeSequence < burstSize){
            if(isLoaded) {
                Shoot();
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