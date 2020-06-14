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


    private void Awake() {
        crosshair = GetComponentInChildren<DynamicCrosshair>();
    }

    private void Update() {
        crosshair.UpdateBloom(ScaleDegreesToScreen(player.OnHand.Bloom*2));
    }

    private float ScaleDegreesToScreen(float value) {
        float degreesPerPixel = 1080/player.Head.Camera.fieldOfView;
        return degreesPerPixel * value;
    }
}

