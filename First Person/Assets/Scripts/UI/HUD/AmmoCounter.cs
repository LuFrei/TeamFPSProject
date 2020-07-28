using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    private Text ammoCount;

    private void Awake() {
        ammoCount = GetComponent<Text>();
    }

    public void SetCounterValue(int magazineAmmo, int reserveAmmo) {
        ammoCount.text = $"{magazineAmmo} / {reserveAmmo}";
    }
}
