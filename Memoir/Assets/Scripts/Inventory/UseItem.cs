using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem: MonoBehaviour{

    //returns items which will be added to the inventory;
    public virtual List<Item> useItem(Item item){
        print("Used " + item.name);

        return defaultAction();
    }    


    public ItemManager getItemManager(){
        return GameObject.Find("Inventory Manager").GetComponent<ItemManager>();
    }
    public Item makeItem(string id, int num){
        ItemManager im = getItemManager();
        Item newItem = im.createFromId(id);
        newItem.number = num;

        return newItem;
    }    

    public List<Item> defaultAction(){
        print("This thing doesn't do anything for me here...");
        return new List<Item>();  
    }

    public List<Item> defaultUseItem(string item, int numUsed){
        List<Item> changeList = new List<Item>();
        changeList.Add(makeItem(item, -1 * numUsed));
        return changeList;
    }

    public List<Item> defaultGetItem(string item, int numGet){
        List<Item> changeList = new List<Item>();
        changeList.Add(makeItem(item, numGet));
        return changeList;
    }

    public List<Item> defaultTradeItems(string itemLost, int numUsed, string itemGot, int numGet){
        List<Item> changeList = new List<Item>();
        changeList.Add(makeItem(itemLost, -1 * numUsed));
        changeList.Add(makeItem(itemGot, numGet));

        return changeList;
    }
}
