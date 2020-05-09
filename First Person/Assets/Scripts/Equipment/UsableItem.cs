using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UsableItem : MonoBehaviour{

    protected RaycastHit hitInfo;//This is used to take info from FPSCam and pass it on to individual item for use

    public virtual void PrimaryAction() { }
    public virtual void SecondaryAction() { }
    public virtual void ChangeMode() { }
}
