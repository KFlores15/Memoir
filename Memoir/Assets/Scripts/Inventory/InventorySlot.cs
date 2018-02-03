using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Item item;                   //changing does not change underlying structure
    public string ResourcesItemPath;    // to be set by InventoryManager, not programer
    public GameObject displayPanel;
    public GameObject spriteObject;     // Set by Prefab, no need to touch
    public GameObject nameObject;       // Set by Prefab, no need to touch
    public GameObject numberObject;     // Set by Prefab, no need to touch
    public GameObject hoverObject;      // Set by Prefab, no need to touch
    public GameObject hoverObjectName;  
    public GameObject hoverObjectText;  // Set by Prefab, no need to touch
    Image image;
    Text nameText;
    Text numberText;
    Text hoverNameText;
    Text hoverText;
    
    public void Awake() {
        image = spriteObject.GetComponent<Image>();
        nameText = nameObject.GetComponent<Text>();
        numberText = numberObject.GetComponent<Text>();
        hoverNameText = hoverObjectName.GetComponent<Text>();
        hoverText = hoverObjectText.GetComponent<Text>();
        hoverObject.SetActive(false);
    }
    
    public void UpdateSlot(Item newItem){
        item = newItem;
    
        if(item.number == 0){
            Visable(false);
        }else{
            Visable(true);
        }        
        
        //image.sprite = Resources.Load<Sprite>(ResourcesItemPath + "bluestar");
        nameText.text = item.name;
        hoverNameText.text = item.name;
        numberText.text = item.number.ToString();
        hoverText.text = item.description;

        name = "InvSlot: " + item.name + ", " + item.number.ToString();
    }

    public void Visable(bool state){

        spriteObject.SetActive(state);
        nameObject.SetActive(state);
        numberObject.SetActive(state);  
        
    }

     public void OnPointerEnter(PointerEventData eventData)
     {
        hoverObject.SetActive(true);
        hoverObject.transform.SetParent(displayPanel.transform.parent, true);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {

        hoverObject.transform.SetParent(this.transform, true);
        hoverObject.SetActive(false);
     }


    public void changeSprite(string newImage){
        image.sprite = Resources.Load<Sprite>(ResourcesItemPath + newImage);
    }
}
