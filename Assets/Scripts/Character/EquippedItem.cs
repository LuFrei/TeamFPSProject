using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    /// <summary>
    /// Position the Item should be placed or snapped to.
    /// </summary>
    [SerializeField] private Transform itemHolder;

    [SerializeField] private  itemDataRight;
    [SerializeField] private GameObject rightHandItem;

    public UsableItem CurrentRightEquipped => itemDataRight;

    private void Awake() {
        // TODO: This is proably why when reloading scenes, the weapon is in the wrong place.
        //       set item.
        itemHolder = transform;
    }

    public void ChangeHand(GameObject item) {
        if(transform.childCount > 0) {
            //If we any items on hand, clear them;
            for(int i = transform.childCount; i > 0; i--) {
                Destroy(transform.GetChild(i - 1).gameObject);
            }
        }
        rightHandItem = Instantiate(item, itemHolder);
        itemDataRight = rightHandItem.GetComponent<UsableItem>();
    }
}
 