using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : UsableItem
{
    [Header("Dependencies")]
    [SerializeField] private Transform bulletPoint;

    [Header ("Weapon Attributes")]
    [SerializeField]private float rateOfFire; //in Rounds per Min
    [SerializeField]private float damage;
    
    [SerializeField]private float reloadLength; //in Seconds
    [SerializeField]private int magSize; //Just in case... "0" will be treated as infinite for both mag and pool size (for possible in-game match editing)
    [SerializeField]private int ammoPoolLimit; 
    
    [SerializeField]private float hipAccuracy; //hip-fire bloom
    [SerializeField]private float aimAccuracy; //ADS bloom (NOTE: This should not be set high. Shots should still land REASNOABLY close to aimed location

    //Bullet info
    [SerializeField]private GameObject bullet;

    //TODO: Recoil algorithm. This sh ould be adjustable for every individual weapon:
    //1. the "cone" path of the bounce
    //2. the "power" of each kick
    //3. the "reset" value of the recoil

        //NOTE: I'll have to find a way to generate a ray based on accuracy, for now it'll just shoot straight
    public void Shoot(){
        Instantiate(bullet, bulletPoint.position, Quaternion.Euler(Vector3.forward));
        Debug.Log("I went bang!");
    }



    //UsableItem integration
    public override void PrimaryAction()
    {
        Shoot(); 
    }

}
