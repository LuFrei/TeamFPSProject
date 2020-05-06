using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UsableItem : MonoBehaviour{
    public virtual void PrimaryAction() { }
    public virtual void SecondaryAction() { }
    public virtual void ChangeMode() { }
}
