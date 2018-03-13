using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : Slot, IPointerClickHandler {

    public GameObject nameObject;       // Set by Prefab, no need to touch
    public GameObject DescriptionObjectText;  // Set by Prefab, no need to touch
    
    Text nameText;
    Text descriptionText;
    
    public override void Awake() {
        base.Awake();
        nameText = nameObject.GetComponent<Text>();
        descriptionText = DescriptionObjectText.GetComponent<Text>();
    }

    public override void UpdateSlot(Item newItem){
        base.UpdateSlot(newItem);

        nameText.text = item.name;
        descriptionText.text = item.description;
    }

    public override void Visable(bool state){
        base.Visable(state);

        nameObject.SetActive(state); 
    }

    public void OnPointerClick(PointerEventData eventData) {
        im.setActiveItem(item.id);
    }
}