using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager: MonoBehaviour
{
    //Dependencies
    public FPSCharacterController player;
    public Canvas canvas;

    //HUD Elements
    public DynamicCrosshair crosshair;
    public AmmoCounter ammo;


    private void Awake() {
        crosshair = GetComponentInChildren<DynamicCrosshair>();
        ammo = GetComponentInChildren<AmmoCounter>();
    }

    private void Update() {
        crosshair.UpdateBloom(ScaleDegreesToScreen(player.OnHand.Accuracy.Bloom * 2));
        ammo.SetCounterValue(player.OnHand.Ammo.MagAmmo, player.OnHand.Ammo.ReserveAmmo);
    }
    
    private float ScaleDegreesToScreen(float value) {
        float degreesPerPixel = 1080/player.Head.Camera.fieldOfView;
        return degreesPerPixel * value;
    }
}

