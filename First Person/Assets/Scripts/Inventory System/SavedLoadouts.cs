using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedLoadouts: MonoBehaviour {
    [SerializeField] private Loadout[] loadouts;


    public Loadout[] Loadouts => loadouts;


    public void SaveLoadout(Loadout loadout, int index) {
        
    }
}
