using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWG.Equipment {
public class Weapon: UsableItem {
    [Flags] public enum FireMode { Auto = 0, Burst = 1, Single = 2 }
    public FireMode currentMode;
    public int burstSize = 3; //if applicable

    [Header("Dependencies")]
    public WeaponAttributes attributes;
    private Animator anim;
    [SerializeField] private GameObject bullet;

    //vital
    public Ray bulletOrigin; // This needs to be fed in

    //Components that make up a "Weapon"
    private AccuracySpread accuracy = new AccuracySpread();
    private Ammo ammunition = new Ammo();

    //Chamber and Trigger
    private bool isLoaded = true; //Ready to shoot the next bullet
    private bool isReceivingInput; //Am I recieving input?
    private bool isBusy = false; //Am I ready for the next input?

    //Aiming
    private float aimingSpeed;
    private float walkingSpeed;
    private float aimZoom = 1.2f;

    public override AccuracySpread Accuracy => accuracy;
    public override Ammo Ammo => ammunition;

    
    private void Awake() {
        accuracy.SetNewBloomSource(attributes.HipAccuracy);
        ammunition.SetMagSize(attributes.MagSize);
        ammunition.RestockAmmo(attributes.AmmoReserveLimit);
        anim = GetComponent<Animator>();
    }

    private void Update() {
            // TODO: Move to camera Script; change check from if notBusy, to if notAtRest
        //if(!isBusy) {
        //    FPSCam.ResetView(attributes.RecoilRecovery);
        //}
        accuracy.RecoverBloom(attributes.BloomRecoveryTime);
    }


    private void Shoot(float kickMagnitude) {
        anim.SetTrigger("shot");
            // TODO: inject data like Bulletorigin from camera.
            // TODO: Make GenerateRandomDeviation a weapon method.
            //Instantiate(bullet, FPSCam.Ray.origin, FPSCam.GenerateRandomDeviation(accuracy.Bloom));
            Instantiate(bullet, bulletOrigin.origin, GenerateRandomDeviation(accuracy.Bloom));
            // TODO: Call this in the CharacterController.
            // FPSCam.Kick(kickMagnitude, attributes.RecoilControl);
            accuracy.AddBloom(attributes.Stability);
        isLoaded = false;
        StartCoroutine(CycleShot());
    } 

    private IEnumerator CycleShot() {
        float loadBuffer = 0;
        if(ammunition.ExpendBullet()) {
            while(loadBuffer < 1) {
                loadBuffer += Time.deltaTime * attributes.RateOfFire;
                anim.SetFloat("cycleProgress", loadBuffer);
                yield return null;
            }
            isLoaded = true;
        } else {
            anim.SetBool("isEmpty", true);
            isBusy = false;
        }
    }

    public Quaternion GenerateRandomDeviation(float maxMagnitude) {
        Quaternion newDirection = Quaternion.LookRotation(bulletOrigin.direction);
        float angle = UnityEngine.Random.Range(0, 360);
        float magnitude = UnityEngine.Random.Range(0, maxMagnitude);
        newDirection *= Quaternion.AngleAxis(angle, Vector3.forward);
        newDirection *= Quaternion.AngleAxis(magnitude, Vector3.right);
        return newDirection;
    }

        #region Aiming Functions
        void ToAimDownSight(float zoomMultiplier) {
            // TODO: call this inside of Camera Script; tie to ADS event
        //FPSCam.Zoom(zoomMultiplier);
        accuracy.SetNewBloomSource(attributes.AimAccuracy);
    }

    void ToHipfire() {
            // TODO: same as above
        //FPSCam.Zoom(1);
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
        int activeSequence = 0;
        isBusy = true;
        while(activeSequence < burstSize){
            if(isLoaded) {
                Shoot(attributes.Recoil);
                activeSequence++;
            }
            yield return null;
        }
        isBusy = false;
    }
    #endregion

    #region UsableItem Methods
    public override void PrimaryActionStart() { 
        isReceivingInput = true;
        if(!isBusy && ammunition.MagAmmo > 0) {
            switch(currentMode) {
                case FireMode.Auto:
                    StartCoroutine(AutoFire());
                    break;
                case FireMode.Burst:
                    StartCoroutine(BurstFire());
                    break;
                case FireMode.Single:
                    SingleFire();
                    break;
            }
        }
    }
    public override void PrimaryActionEnd() {
        isReceivingInput = false;
    }

    public override void SecondaryActionStart() {
        ToAimDownSight(aimZoom);
    }
    public override void SecondaryActionEnd() {
        ToHipfire();
    }
    public override void Reload() {
        if(ammunition.ReserveAmmo > 0) StartCoroutine(ammunition.Reload(attributes.ReloadSpeed, anim));
        isLoaded = true;
    }
    public override void ChangeMode() {
        if(currentMode < FireMode.Single) {
            currentMode++;
        } else {
            currentMode = FireMode.Auto;
        }
    }
    #endregion
}
}