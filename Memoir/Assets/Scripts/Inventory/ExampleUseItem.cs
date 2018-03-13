using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleUseItem : UseItem {

    public override List<Item> useItem(Item item){
        //base.useItem(item);

        return complexBehaviorExample(item);
    }   

    List<Item> complexBehaviorExample(Item item){

        switch(item.id){
            case ("wand"):
                print("Got a new wand!");
                return defaultGetItem("wand", 1);
            case ("bat"):
                print("Traded my bat for some wands!");
                return defaultTradeItems("bat", 1, "wand", 2);
            case ("papers"):
                print("Ah, I lost some of my papers...");
                return defaultUseItem("papers", 1);
            default:
                defaultAction();
                return new List<Item>();
        }
    } 
}
