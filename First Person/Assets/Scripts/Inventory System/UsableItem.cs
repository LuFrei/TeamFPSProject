using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UsableItem: MonoBehaviour {

    protected Vector3 rayDir;//This is used to take info from FPSCam and pass it on to individual item for use
    public Vector3 RayDirection { set => rayDir = value; }
    public virtual AccuracySpread Accuracy { get; }
    public virtual Ammo Ammo { get; }
    public virtual void OnPrimaryActionStart() { }
    public virtual void OnPrimaryActionEnd() { }
    public virtual void OnSecondaryActionStart() { }
    public virtual void OnSecondaryActionEnd() { }
    public virtual void OnReload() { }
    public virtual void ChangeMode() { }
}
