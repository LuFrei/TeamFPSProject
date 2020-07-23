using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitcher : MonoBehaviour
{
    private Inventory inv;

    private void Awake() {
        inv = GetComponentInParent<Inventory>();
    }

     
}
