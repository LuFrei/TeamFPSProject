using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo
{
    //constraints
    public bool preserveBulletsOnReload = true;
    public bool infiniteAmmo;


    private int magazineAmmo;
    private int reserveAmmo;
    private int maxMagazines = 8;

    private int magSize;

    public int MagAmmo => magazineAmmo;
    public int ReserveAmmo => reserveAmmo;


    public Ammo(int maxMagValue, int defaultReserveSize) {
        magSize = maxMagValue;
        magazineAmmo = magSize;
        reserveAmmo = magSize * defaultReserveSize;
    }

    /// <summary>
    /// Set how much bullets in a given magazine
    /// </summary>
    /// <param name="value"></param>
    /// <param name="magazine">What magainze you want to set, defaults to magazine currently being used</param>
    public void SetMagValue(int value) {
        magazineAmmo = value;
    }

    /// <summary>
    /// Spends a bullet from the maganize. Returns false if magainze is empty.
    /// </summary>
    /// <param name="bulletsToExpend">How many bullets to spend per call. Default to one. </param>
    /// <returns>returns false if mag is empty or on last bullet</returns>
    public bool ExpendBullet(float bulletsToExpend = 1) {
        if(magazineAmmo > 0) {
            magazineAmmo--;
            if(magazineAmmo > 0) {
                return true;
            }
            return false; 
        }
        return false;
    }

    public IEnumerator Reload(float speed, Animator anim) {
        //get how empty thr Mag is
        int valueDifference = magSize - magazineAmmo;
        int transferableValue = reserveAmmo - valueDifference;
        float reloadTimer = 0;
        anim.SetTrigger("reload");
        anim.SetBool("isEmpty", false);

        while(reloadTimer < 1) {
            reloadTimer += Time.deltaTime * speed;
            anim.SetFloat("reloadProgress", reloadTimer);
            yield return null;
        }


        switch(preserveBulletsOnReload) {
            case true:
                if(transferableValue > 0) {
                    reserveAmmo -= valueDifference;
                    magazineAmmo += valueDifference;
                } else {
                    reserveAmmo = 0;
                    magazineAmmo += valueDifference + transferableValue;
                }
                break;
            case false:
                if(transferableValue > 0) {
                    reserveAmmo -= magSize;
                    magazineAmmo += valueDifference;
                } else {
                    reserveAmmo = 0;
                    magazineAmmo += valueDifference + transferableValue;
                }
                break;
        }
    }

    public void RestockAmmo(int value) {
            reserveAmmo += magSize * value;
    }
}
