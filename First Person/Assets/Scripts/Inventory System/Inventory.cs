using System.Collections;
using System.Collections.Generic;

//Inventory system will use a NumID system that can be assigned to anything outside of this class.
//0 will Always be treated as "empty"
public class Inventory
{
    private int size;
    private int[] inventory;
    private int currentIndex;

    public int Size { get; }
    public int CurrentIndex { get; }

    public Inventory(int inventorySize){
        size = inventorySize;
        inventory = new int[size];
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
        inventory[index] = 0;
    }
    public void Set(int index, int itemID){
        inventory[index] = itemID;
    }
    /// <summary>
    /// Returns ItemID of currentIndex
    /// </summary>
    /// <returns>ItemID</returns>
    public int Get(){
        return inventory[currentIndex];
    }
    /// <summary>
    /// Returns ItemID of specified index
    /// </summary>
    /// <param name="index">inventory "slot"</param>
    /// <returns>ItemID</returns>
    public int Get(int index){
        return inventory[index];
    }

}
