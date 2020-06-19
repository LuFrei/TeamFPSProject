using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo
{
    public bool preserveBulletsOnReload;

    public bool infiniteAmmo;


    private int magazineAmmo;
    private int reserveAmmo;
    private int maxMagazines = 8;

    private int magSize;

    private float reloadProgress;

    public int MagAmmo => magazineAmmo;
    public int ReserveAmmo => reserveAmmo; 

    public Ammo(int maxMagValue) {
        magSize = maxMagValue;
        magazineAmmo = magSize;
        reserveAmmo = magSize * 4;
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
    /// <returns>returns false if mag is empty</returns>
    public bool ExpendBullet(float bulletsToExpend = 1) {
        if(magazineAmmo > 0) {
            magazineAmmo--;
            return true;
        }
        return false;
    }

    public void Reload(float speed) {
        int valueDifference = magSize - magazineAmmo;
        int transferableValue = reserveAmmo - valueDifference;

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
