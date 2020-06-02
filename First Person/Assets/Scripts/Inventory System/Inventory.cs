using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inventory system will use a NumID system that can be assigned to anything outside of this class.
//0 will Always be treated as "empty"
public class Inventory : MonoBehaviour
{
    private int size;
    private UsableItem[] inventory;
    private int currentIndex;

    public int Size { get; }
    public int CurrentIndex { get; }

    public Inventory(int inventorySize){
        size = inventorySize;
        inventory = new UsableItem[size];
    }

    //Inventory Navigation functions
    public void GoTo(int index){
        currentIndex = index;
    }
    public void GoDown(){
        if (currentIndex > 0) currentIndex--;
    }
    public void GoUp(){
        if (currentIndex < size--) currentIndex++;
    }

    //Inventory Manipulation funcations
    public void Clear(int index){
        inventory[index] = null;
    }
    public void Set(int index, UsableItem item){
        inventory[index] = item;
    }
    /// <summary>
    /// Returns ItemID of currentIndex
    /// </summary>
    /// <returns>ItemID</returns>
    public UsableItem Get(){
        return inventory[currentIndex];
    }
    /// <summary>
    /// Returns ItemID of specified index
    /// </summary>
    /// <param name="index">inventory "slot"</param>
    /// <returns>ItemID</returns>
    public UsableItem Get(int index){
        return inventory[index];
    }

}
