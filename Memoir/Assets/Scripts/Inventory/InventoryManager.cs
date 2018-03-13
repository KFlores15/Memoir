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

    InventoryDictionary invDict;
    public string defaultInventoryName = "default";

    private int maxNumItem = 1000;

    public string activeItem = "";
    public GameObject mouseSlot; 

    // Use this for initialization
    void Awake () {
        invDict = new InventoryDictionary(defaultInventoryName);
        inv = invDict.getInventory();
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
        if(Input.GetMouseButtonDown(0)){
            onActiveItemUse();
        }
    }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Inventory Panel Operations
// Mainly handles keeping front end inventory display (inventory slots) up to date with the underlying backend
//

    GameObject InstantiateSlot(int index){
        if(inventoryToggledPannel.activeInHierarchy){
            GameObject invSlot = Instantiate(invetorySlotPrefab, inventoryContentPanel.transform);
            inventoryArray.Add(invSlot);
            InventorySlot slot = invSlot.GetComponent<InventorySlot>();
            slot.ResourcesItemPath = ResourcesItemPath;
            slot.im = this;
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

    public void clearInventory(){
        for( int i = inventoryArray.Count - 1; i>=0; i-- ){
            removeItem(inv.getID(i), maxNumItem);
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
       }else if(index >= inv.Count()){
            //destroy the slot if there is no contents
            slotObject = inventoryArray[index];
            Destroy(slotObject);
            inventoryArray.Remove(slotObject);
            return true;
        }else{ //otherwise just grab it
            slotObject = inventoryArray[index];
        }

        //get the part which makes it an Inventroy Slot
        InventorySlot slot = slotObject.GetComponent<InventorySlot>();

        //Then update!
        slot.UpdateSlot(inv.getItem(index));
        
        return true;
    }

    void updateAllSlots(){
        for(int i = 0; i< Mathf.Max(inv.Count(), inventoryArray.Count); i++){ 
            updateSlot(i);
        }
    }

///////////////////////////////////////////////////////////////////////////////////////////////
// Inventory Dictionary Operations
// This allows multiple inventories to be kept and saved all in one place
// Only one is ever active at a given time

    public string getNameOfActiveInv(){
        return invDict.getNameOfActive();
    }

    public bool addInventory(string newName){
        return invDict.addInventory(newName);
    }

    public bool changeInventories(string otherInvName){
        Inventory newInv = invDict.changeActiveInv(otherInvName);
        if(newInv != null){
            inv = newInv;
            updateAllSlots();
            return true;
        }else{
            return false;
        }
    }

    public bool removeInventory(string nameToRemove){
        return invDict.removeInventory(nameToRemove);
    }

///////////////////////////////////////////////////////////////////////////////////////////////////
// Interactable Objects:
//

    public void setActiveItem(string id){
        if(activeItem != id && id!=""){
            activeItem = id;
            mouseSlot.GetComponent<MouseSlot>().UpdateSlot(inv.getItem(id));
            inventoryToggledPannel.SetActive(false);
        }else{
            activeItem = "";
            mouseSlot.GetComponent<MouseSlot>().clearSlot();
        }
    }

    UseItem checkItemUse(RaycastHit2D hit){
        if( activeItem   == "" ||  
            hit.collider == null) return null;

        UseItem obj= hit.collider.gameObject.GetComponent<UseItem>();

        if(obj == null) return null;
        else return obj;
    }

    void onActiveItemUse(){

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        UseItem obj = checkItemUse(hit);
        if(obj != null){
            List<Item> itemBack = obj.useItem(inv.getItem(activeItem));

            foreach(Item item in itemBack){
                addItem(item);
            }
            setActiveItem("");
        }
    } 

}
        