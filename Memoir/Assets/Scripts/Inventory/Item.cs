using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{
    public string name = "Default Item";    //: may be displayed
    public string id = "item0";     //: intended to be set then 
                                    // never changed for reference in code
    public int number = 0;          //: number in player's possession
    public string description = "An item whose decription has not been set. Most curious...";
    public string spriteName = "default";

    public Item(){}
    public Item( string ID, int Number){
        id = ID;
        number = Number;
    }
    public Item( string Name, string ID, int Number):this(ID, Number){
        name = Name;
    }

    public Item(string Name, string ID, int Number, string Desc): this(Name, ID, Number){
        description = Desc;
    }

    public Item(string Name, string ID, int Number, string Desc, string SpriteName): this(Name, ID, Number, Desc){
        spriteName = SpriteName;
    }

    public Item copy(){
        return new Item(name, id, number, description, spriteName);
    }
}
