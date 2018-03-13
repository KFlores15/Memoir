using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public Item item;                   //changing does not change underlying structure
    public string ResourcesItemPath;    // to be set by InventoryManager, not programer
    public GameObject spriteObject;     // Set by Prefab, no need to touch
    public GameObject numberObject;     // Set by Prefab, no need to touch
    public InventoryManager im; //set by InventoryManager, no need to touch
    protected Image image;
    protected Text numberText;

    
    public virtual void Awake() {
        image = spriteObject.GetComponent<Image>();
        numberText = numberObject.GetComponent<Text>();
    }

    public virtual void UpdateSlot(Item newItem){
        item = newItem;
    
        if(item.number == 0){
            Visable(false);
        }else{
            Visable(true);
        }

        Sprite sprite = Resources.Load<Sprite>(ResourcesItemPath + item.spriteName);
        if(sprite != null){
            image.sprite = sprite;
        }
        numberText.text = item.number.ToString();

        name = "InvSlot: " + item.name + ", " + item.number.ToString();
    }

    public virtual void Visable(bool state){

        spriteObject.SetActive(state);
        numberObject.SetActive(state);  
        
    }

    public void changeSprite(string newImage){
        image.sprite = Resources.Load<Sprite>(ResourcesItemPath + newImage);
    }
}
