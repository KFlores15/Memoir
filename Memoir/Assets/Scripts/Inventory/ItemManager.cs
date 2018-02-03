using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemManager: MonoBehaviour {

    public List<Item> database;

    public void addItem(Item newItem){
        database.Add(newItem.copy());
    }

    public Item createFromId(string id){
        for(int i=0; i< database.Count; i++){
            if(database[i].id == id) return database[i].copy();
        }
        return new Item("ERROR: "+id, "ERROR:"+id, -2, "ERROR: Item \""+id+"\" does not exist in the database! Make sure that the right id was usedor that it was added to the database properly!");
    }

}
