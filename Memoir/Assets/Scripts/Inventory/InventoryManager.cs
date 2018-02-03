using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    Inventory inv;
    public ItemManager itemManager;
    public string ResourcesItemPath;
    public GameObject invetorySlotPrefab; //must have an InventorySlot on it
    public GameObject inventoryPanel;     //must be a canvas or inside of one
    public GameObject hoverObject;        //should be lower in hierarchy than panel to display properly
    List<GameObject> inventoryArray;

	// Use this for initialization
	void Start () {
        
        inv = new Inventory();
        inventoryArray = new List<GameObject>();
        inv.addItem("Basement Key", "basementkey1", 1);

        for(int i=0; i< inv.Count(); i++){
            inventoryArray.Add(InstantiateSlot(i));
        }


        addItem(new Item("Baseball Bat", "bat", 1));
        addItem(new Item("School Papers", "papers", 12));
        addItem("wand", 27);
        addItem("test", 7);

        removeItem("bat", 1);
        renameItem("papers", "Important Documents");
        changeItemDescription("papers", "These look important, maybe I should hold onto them for now.");
        changeItemSprite("papers", "MagicBook");
        
	}
	
    GameObject InstantiateSlot(int index){
        GameObject invSlot = Instantiate(invetorySlotPrefab, inventoryPanel.transform);
        InventorySlot slot = invSlot.GetComponent<InventorySlot>();
        slot.ResourcesItemPath = ResourcesItemPath;
        slot.displayPanel = inventoryPanel;
        slot.UpdateSlot(inv.getItem(index));
        //slot.hoverObject = hoverObject;
        return invSlot;
    }

    public void addItem( Item item){
        inv.addItem(item);
        int index = inv.findItemIndex(item.id);
        if(index >= inventoryArray.Count) inventoryArray.Add(InstantiateSlot(index));
        
        if(index != -1) updateSlot(index);
    }
    public void addItem( string id, int number){
        Item item = itemManager.createFromId(id);
        item.number = number;
        addItem(item);
    }

    public void removeItem( string id, int number){
        inv.removeItem(id, number);
        int index = inv.findItemIndex(id);
        if(index != -1) {
            updateSlot(index);
        }

        if(inv.getNum(index) <= 0){
            inv.deleteItem(id);
            Destroy(inventoryArray[index]);
            inventoryArray.RemoveAt(index);
        }
    }

    public void swapItems(string idA, string idB){
        if(idA == idB) return; //same item, no need to swap, so stop

        int indexA = inv.findItemIndex(idA);
        int indexB = inv.findItemIndex(idB);

        if(!inv.validItem(indexA) || !inv.validItem(indexB)) return; //one (or both) is missing, stop

        inv.swapItems(indexA, indexB);
        updateSlot(indexA);
        updateSlot(indexB);
    }

    public void renameItem( string id, string newName){
        int index = inv.findItemIndex(id);
        if(inv.validItem(index)){
            inv.renameItem(id, newName);
            updateSlot(index);
        }
    }
    
    public void changeItemDescription(string id, string newDescription){
        int index = inv.findItemIndex(id);
        if(inv.validItem(index)){
            inv.changeDescription(id, newDescription);
            updateSlot(index);
        }
    }

    public void changeItemSprite(string id, string newImageName){
        int index = inv.findItemIndex(id);
        if(inv.validItem(index)){
            inventoryArray[index].GetComponent<InventorySlot>().changeSprite(newImageName);
            updateSlot(index);
        }
    }

    void updateSlot(int index){
        inventoryArray[index].GetComponent<InventorySlot>().UpdateSlot(inv.getItem(index));
    }

}
