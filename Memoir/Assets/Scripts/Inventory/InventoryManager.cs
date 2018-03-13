using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public List<string> initialItems;       //allows you to place items in player's inventory on load
                                            //largly for testing purposes
                                            //currently limited to one item at a time
    Inventory inv;                          //Backend storage of items
    public ItemManager itemManager;         //keeps record of all possible items in game
    public string ResourcesItemPath;        //if items get put in a sub folder in resources

                                            //Game Object Requirements:
    public GameObject invetorySlotPrefab;   //must have an InventorySlot on it
    public GameObject inventoryToggledPannel;      //all displayed inventory things must be under this object
                                                   //inventory manager must be above it
    public GameObject inventoryContentPanel;       //must be a canvas or inside of one
    List<GameObject> inventoryArray;

    // Use this for initialization
    void Awake () {
        inv = new Inventory();
        inventoryArray = new List<GameObject>();

        for(int i=0; i< inv.Count(); i++){
            inventoryArray.Add(InstantiateSlot(i));
        }

        foreach( string item in initialItems){
            addItem(item, 1);
        }
        
    }

    public void Update() {
        //open or close menu
        if(Input.GetKeyDown(KeyCode.Tab)){
            inventoryToggledPannel.SetActive(!inventoryToggledPannel.activeInHierarchy);
            
            //update Inventory Slots on open of Inventory Panel
            if(inventoryToggledPannel.activeInHierarchy){
                updateAllSlots();
            }
        }
    }

    GameObject InstantiateSlot(int index){
        if(inventoryToggledPannel.activeInHierarchy){
            GameObject invSlot = Instantiate(invetorySlotPrefab, inventoryContentPanel.transform);
            inventoryArray.Add(invSlot);
            InventorySlot slot = invSlot.GetComponent<InventorySlot>();
            slot.ResourcesItemPath = ResourcesItemPath;
            slot.displayPanel = inventoryContentPanel;
            slot.UpdateSlot(inv.getItem(index));
            return invSlot;
        }
        return null;
    }

    public void addItem( Item item){
        inv.addItem(item);
        int index = inv.findItemIndex(item.id);
        if(index >= inventoryArray.Count){
            GameObject newSlot = InstantiateSlot(index);
        }
        
        if(index != -1) updateSlot(index);
    }
    public void addItem( string id, int number){
        Item item = new Item(id, number);
        if(itemManager != null){
            item = itemManager.createFromId(id);
        }

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
            if(inventoryArray.Count > index){
                Destroy(inventoryArray[index]);
                inventoryArray.RemoveAt(index);
            }
            
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
            inv.changeSprite(id, newImageName);
            updateSlot(index);
        }
    }

    bool updateSlot(int index){
        //Don't try to update if these things are not active!
        if(!inventoryContentPanel.activeInHierarchy) return false;

        //get the slot to be updated:
        GameObject slotObject;
        if(index >= inventoryArray.Count){
            //create it if it doesn't yet exist:
            slotObject = InstantiateSlot(index);
        }else{
            slotObject = inventoryArray[index];
        }

        //get the part which makes it an Inventroy Slot
        InventorySlot slot = slotObject.GetComponent<InventorySlot>();

        //Then update!
        slot.UpdateSlot(inv.getItem(index));
        
        return true;
    }

    void updateAllSlots(){
        for(int i = 0; i< inv.Count(); i++){
            updateSlot(i);
        }
    }

}
        