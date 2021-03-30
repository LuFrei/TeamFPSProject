using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;

    [SerializeField] private UsableItem itemDataRight;
    [SerializeField] private GameObject rightHandItem;

    public UsableItem CurrentRightEquipped => itemDataRight;

    private void Awake() {
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
 