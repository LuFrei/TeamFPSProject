using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout   {

    //How many of each item type will this loadout have?
    [SerializeField] private int maxWeapons;
    [SerializeField] private int maxTools;
    [SerializeField] private int maxGrenades;
    [SerializeField] private int maxGadgets;


    [SerializeField] private GameObject[] weaponItems = new GameObject[2];
    [SerializeField] private GameObject[] toolItems = new GameObject[1];
    [SerializeField] private GameObject[] grenadeItems = new GameObject[2];
    [SerializeField] private GameObject[] gadgetItems = new GameObject[2];

    public void AddItem(GameObject item, int index) {
        switch(item.tag) {
            case "Weapon":
                weaponItems[index] = item;
                break;
            case "Tool":
                toolItems[index] = item;
                break;
            case "Grenade":
                grenadeItems[index] = item;
                break;
            case "Gadget":
                gadgetItems[index] = item;
                break;
        }
    }

    public GameObject[] GetPackagedLoadout() {
        List<GameObject> items = new List<GameObject>();

        items.AddRange(weaponItems);
        items.AddRange(gadgetItems);
        items.AddRange(grenadeItems);
        items.AddRange(toolItems);

        return items.ToArray();
    }

}
