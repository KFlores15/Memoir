using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Item item;                   //changing does not change underlying structure
    public string ResourcesItemPath;    // to be set by InventoryManager, not programer
    public GameObject displayPanel;
    public GameObject spriteObject;     // Set by Prefab, no need to touch
    public GameObject nameObject;       // Set by Prefab, no need to touch
    public GameObject numberObject;     // Set by Prefab, no need to touch
    public GameObject DescriptionObjectText;  // Set by Prefab, no need to touch
    Image image;
    Text nameText;
    Text numberText;
    Text descriptionText;
    
    public void Awake() {
        image = spriteObject.GetComponent<Image>();
        nameText = nameObject.GetComponent<Text>();
        numberText = numberObject.GetComponent<Text>();
        descriptionText = DescriptionObjectText.GetComponent<Text>();
    }
    
    public void UpdateSlot(Item newItem){
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
        print(item.name);
        nameText.text = item.name;
        numberText.text = item.number.ToString();
        descriptionText.text = item.description;

        name = "InvSlot: " + item.name + ", " + item.number.ToString();
    }

    public void Visable(bool state){

        spriteObject.SetActive(state);
        nameObject.SetActive(state);
        numberObject.SetActive(state);  
        
    }

    public void changeSprite(string newImage){
        image.sprite = Resources.Load<Sprite>(ResourcesItemPath + newImage);
    }
}
