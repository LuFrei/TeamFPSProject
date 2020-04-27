using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableLoadoutItem : MonoBehaviour
{
    //Equipments are items that can be slotted into a Player Inventory.
    //Every Equipment is interactible by the player, but each action might have a different function depending on what equipment is being used
    protected int ItemID;


    public virtual void Use(){}
    public virtual void AltUse(){}
    public virtual void ChangeMode(){}
}
