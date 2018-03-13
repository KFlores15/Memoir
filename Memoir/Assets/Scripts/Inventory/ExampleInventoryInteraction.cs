using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInventoryInteraction : MonoBehaviour {
    
	void Start () {
        //for testing and demonstration:
        InventoryManager im = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();

        im.addItem("bat", 1);
        im.addItem("papers", 12);
        im.addItem("wand", 27);
        //im.addItem("test", 7);  //If the Item Manager is set up properly this last one
                                //should result in an "error". Game will run, 
                                //but item will very clearly be wrong

        im.removeItem("bat", 1);
        im.renameItem("papers", "Important Documents");
        im.changeItemDescription("papers", "These look important, maybe I should hold onto them for now.");
        im.changeItemSprite("papers", "MagicBook");
        im.swapItems("papers", "wand");
        //end of test and demonstration section
	}

}
