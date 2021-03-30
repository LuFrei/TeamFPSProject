using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inventory system will use a NumID system that can be assigned to anything outside of this class.
//0 will Always be treated as "empty"
public class PlayerInventory : MonoBehaviour
{
    private int size;
    public GameObject[] inventory;
    private int lastIndex;

    public int Size => size;
    public int LastIndex => lastIndex;

    public PlayerInventory(int inventorySize){
        size = inventorySize;
        inventory = new GameObject[size];
    }

    //Inventory Navigation functions
    public void GoTo(int index){
        lastIndex = index;
    }
    public void GoDown(){
        if (lastIndex > 0) lastIndex--;
    }
    public void GoUp(){
        if (lastIndex < size--) lastIndex++;
    }

    //Inventory Manipulation funcations
    public void Clear(int index){ 
        inventory[index] = null;
    }
    public void Set(int index, GameObject item){
        inventory[index] = item;
    }
    /// <summary>
    /// Returns ItemID of currentIndex
    /// </summary>
    /// <returns>ItemID</returns>
    public GameObject Get(){
        return inventory[lastIndex];
    }
    /// <summary>
    /// Returns ItemID of specified index
    /// </summary>
    /// <param name="index">inventory "slot"</param>
    /// <returns>ItemID</returns>
    public GameObject Get(int index){
        return inventory[index];
    }

}
