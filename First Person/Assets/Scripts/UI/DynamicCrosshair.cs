using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicCrosshair : MonoBehaviour
{
    //Internal Data
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Sprite[] styles;
    [SerializeField] private Image[] ticks;


    private void Awake() {
        crosshair = GetComponent<RectTransform>();
    }



    public void UpdateBloom(float radius) {
        crosshair.sizeDelta = new Vector2(radius, radius);
    }
    public void ChangeStyle(int styleIndex) {
        foreach(Image tick in ticks) {
            tick.sprite = styles[styleIndex];
        }
    }

    public void DisableCrosshairs(bool on) {
    }

    public void DisableRecticle(bool on) {

    }
}
