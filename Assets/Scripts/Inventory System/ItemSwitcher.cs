using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitcher : MonoBehaviour
{
    private PlayerInventory inv;

    private void Awake() {
        inv = GetComponentInParent<PlayerInventory>();
    }

     
}
