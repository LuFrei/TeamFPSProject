using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWG.Character {
public class Health: MonoBehaviour {
    public float value;
    public float maxValue;

    public void Damage(float dmgVal) {
        value -= dmgVal;
    }

    public void Heal(float healVal) {
        value += healVal;
        if(value > maxValue)
            value = maxValue;
    }
}
}
