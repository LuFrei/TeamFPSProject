﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UsableItem : MonoBehaviour{

    protected Vector3 rayDir;//This is used to take info from FPSCam and pass it on to individual item for use
    public Vector3 RayDirection { set => rayDir = value; }

    public virtual void PrimaryAction() { }
    public virtual void SecondaryAction() { }
    public virtual void ChangeMode() { }
}