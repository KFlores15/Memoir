using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDictionary {
    public List<string> inventoryNames;
    Inventory activeInventory;
    string activeInventoryName;
    List<Inventory> inventoryList;

    public InventoryDictionary(string initialInventory){
        inventoryNames = new List<string>();
        inventoryList = new List<Inventory>();

        activeInventoryName = initialInventory;
        activeInventory = new Inventory();
        internal_addInventory(initialInventory, activeInventory);
    }

    public string getNameOfActive(){
        return activeInventoryName;
    }

    public Inventory getInventory(){
        return activeInventory;
    }

    public bool addInventory(string name){
        int index = internal_findIndex(name);
        if(index == -1){
            Inventory newInv = new Inventory();
            internal_addInventory(name, newInv);
            return true;
        }else{
            return false; // inventory already exists, don't add another one!
        }
    }

    public Inventory changeActiveInv(string name){
        int index = internal_findIndex(name);
        if(index != -1){
            activeInventory = inventoryList[index];
            activeInventoryName = name;
            return getInventory();
        }

        return null;
    }
    
    public bool removeInventory(string nameToRemove){
        int index = internal_findIndex(nameToRemove);
        if(index != -1){
            internal_removeInventoryAt(index);
            return true;
        }else{
            return false; //can't remove what isn't there
        }
    }

    void internal_addInventory(string name, Inventory newInv){
        inventoryList.Add(newInv);
        inventoryNames.Add(name);
    }

    void internal_removeInventoryAt(int index){
        inventoryList.RemoveAt(index);
        inventoryNames.RemoveAt(index);
    }

    int internal_findIndex(string name){
        for(int i=0; i< inventoryList.Count; i++){
            if(inventoryNames[i] == name){
                return i;
            }
        }
        return -1;
    }
    
}
