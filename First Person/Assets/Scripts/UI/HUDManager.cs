using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    //HUD Elements
    public DynamicCrosshair crosshair;

    private void Awake() {
        crosshair = GetComponentInChildren<DynamicCrosshair>();
    }
}
