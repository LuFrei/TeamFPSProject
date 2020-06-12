using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    //HUD Elements
    public DynamicCrosshair crosshair;
    
    public FPSCharacterController player;

    private void Awake() {
        crosshair = GetComponentInChildren<DynamicCrosshair>();
    }

    private void Update() {
        crosshair.UpdateBloom(player.OnHand.Bloom);
    }
}
