using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character{
public struct Stats{
    private int maxHealth;
    private int maxSpeed;
    private int jumpStrength;
    private int maxStamina;

    Stats (int maxHealth, int maxSpeed, 
            int jumpStrength, int maxStamina){
        this.maxHealth = maxHealth;
        this.maxSpeed = maxSpeed;
        this.jumpStrength = jumpStrength;
        this.maxStamina = maxStamina;
    }
}
}