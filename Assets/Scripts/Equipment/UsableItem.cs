using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWG.Equipment {
public class UsableItem: MonoBehaviour {

    protected Vector3 rayDir;//This is used to take info from FPSCam and pass it on to individual item for use
    public Vector3 RayDirection { set => rayDir = value; }
    public virtual AccuracySpread Accuracy { get; }
    public virtual Ammo Ammo { get; }
    public virtual void PrimaryActionStart() { }
    public virtual void PrimaryActionEnd() { }
    public virtual void SecondaryActionStart() { }
    public virtual void SecondaryActionEnd() { }
    public virtual void Reload() { }
    public virtual void ChangeMode() { }
}
}