using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : UsableLoadoutItem
{
    private string name;

    [Header ("Weapon Attributes")]
    
    private float damage;
    private float rateOfFire;

    private float reloadSpeed;
    private int magSize; //Just in case... "0" will be treated as infinite for both mag and pool size (for possible in-game match editing)
    private int ammoPoolLimit; 

    private float hipAccuracy; //hip-fire bloom
    private float aimAccuracy; //ADS bloom (NOTE: This should not be set high. Shots should still land REASNOABLY close to aimed location

    //TODO: Recoil algorithm. This should be adjustable for every individual weapon:
    //1. the "cone" path of the bounce
    //2. the "power" of each kick
    //3. the "reset" value of the recoil

    void Shoot()
    {
        Debug.Log("I'm shooting!");
    }

     


}
