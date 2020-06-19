using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracySpread
{
    //Bloom & Accuracy
    public float currentBloom;
    public float baseBloom;
    public float source;
    private float recoverVelocity;

    public float Bloom => currentBloom;

    public void AddBloom(float value) {
        currentBloom += value;
    }
    public void RecoverBloom(float recoverTime) {
        currentBloom = Mathf.SmoothDamp(currentBloom, baseBloom, ref recoverVelocity, recoverTime);
    }

    /// <summary>
    /// Alters default bloom value based on multiplier given 
    /// </summary>
    public void SetBloomModifier(float modifier) {
        baseBloom = source * modifier;
    }

    /// <summary>
    /// What reference will be used to generate bloom data
    /// </summary>
    public void SetNewBloomSource(float source) {
        this.source = source;
        baseBloom = this.source;
    }
}
