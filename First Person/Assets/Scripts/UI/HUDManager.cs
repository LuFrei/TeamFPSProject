using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager: MonoBehaviour
{
    //Dependencies
    public FPSCharacterController player;

    //HUD Elements
    public DynamicCrosshair crosshair;


    private void Awake() {
        crosshair = GetComponentInChildren<DynamicCrosshair>();
    }

    private void Update() {
        crosshair.UpdateBloom(player.OnHand.Bloom);
    }

    private void ScaleDegreesToScreen(float value) {
        //float referenceScale = player.;
    }
}

