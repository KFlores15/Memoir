using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  assumptions:
*   One can have multiples of a given object, 
*   but they would always be in the same stack.
*   (One never needs to split a stack)     
*   
*   One may want a placeholder stack of items 
*   (0 items may be okay in a certain context)
*   This will allow an enforced ordering or a 
*   random/alterable ordering later.
*   
*   One has no reason to have a negative amount of
*   an object. (item.number is a non-negative number)
*/

[System.Serializable]
public class Inventory {
    List<Item> items; 
    
    public Inventory(){
        items = new List<Item>();
    }

//Get Info:
    public int Count(){
        return items.Count;
    }
    public int getNum(string id){
        return items[findItemIndex(id)].number;
    }
    public int getNum(int index){
        return items[index].number;
    }
    public string getName(string id){
        return items[findItemIndex(id)].name;
    }
    public string getName(int index){
        return items[index].name;
    }
    public string getID(int index){
        return items[index].id;
    }
    public Item getItem(int index){
        return items[index].copy();
    }
    public Item getItem(string id){
        return items[findItemIndex(id)].copy();
    }

    public int findItemIndex( string id){
        for(int i=0; i< items.Count; i++){
            if(items[i].id == id) return i;
        }
        return -1;
    }

    public bool validItem( int index){
        if(index != -1 && index < Count()) return true;
                                       else return false;
    }

//Alter Data:
    //increases number of items in inventory by number in Item
    //does not change the name or other value of existing objects!
	public bool addItem( Item item){
        if(item.number < 0){
            return removeItem(item.id, Mathf.Abs(item.number));
        }else{
            int index = findItemIndex(item.id);
            if(!validItem(index)){
                items.Add(item);
            }else{
                items[index].number += item.number;
            }
            return true;
        }
    }
//convenience functions:
    public bool addItem( string name, string id, int number){
        return addItem(new Item(name, id, number));
    }
    public bool addItem( string id, int number){
        return addItem(new Item(id, number));
    }
    public bool addItem(string id){
        return addItem(id, 1);
    }

    //removes number of items of kind associated with the id
    public bool removeItem(string id, int number){
        if(number <= 0){ //are we subtracting a negaitve number? 
            return addItem(id, Mathf.Abs(number)); //add instead
        }else{
            int index = findItemIndex(id);
            if(!validItem(index)){ //have nothing to remove
                return false;
            }else{
                if(items[index].number >= number) {
                    items[index].number -= number; //have enough items to remove
                    return true;
                } else{
                    items[index].number = 0; //remove what we have
                    return false; //report we didn't have enough
                }
            }
            
        }
    }
//convenience functions:
    public bool removeItem(string id){
        return removeItem(id, 1);
    }

    //swaps the location of two items in inventory by index
    public bool swapItems(int indexA, int indexB){
        if(validItem(indexA) && validItem(indexB)){ //A and B are both valid indexes
            swap(indexA, indexB);
            return true;
        }else{
            return false;
        }
    }
    private void swap(int indexA, int indexB){
        Item temp = items[indexA];
        items[indexA] = items[indexB];
        items[indexB] = temp;
    }

    //completely removes an item from the inventory
    public void deleteItem(string id){
        int index = findItemIndex(id);
        if(validItem(index)){
            items.RemoveAt(index);
        }
    }

    //changes the name to be displayed of the object
    public void renameItem(string id, string NewName){
        int index = findItemIndex(id);
        if(validItem(index)) items[index].name = NewName;
    }

    public void changeDescription(string id, string newDescription){
        int index = findItemIndex(id);
        if(validItem(index)) items[index].description = newDescription;
    }
    
    public void changeSprite(string id, string NewSpriteName){
        int index = findItemIndex(id);
        if(validItem(index)) items[index].spriteName = NewSpriteName;
    }

}

