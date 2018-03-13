using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSlot : Slot {
    public Vector3 mouseOffset; 

    public override void Awake() {
        base.Awake();
        Visable(false);
    }

    private void FixedUpdate() {
        //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Input.mousePosition + mouseOffset;
    }

    public override void UpdateSlot(Item newItem){
        base.UpdateSlot(newItem);
        Visable(true);
        name = "MouseSlot: " + item.name + ", " + item.number.ToString();
    }

    public void clearSlot(){
        Visable(false);
        name = "MouseSlot: None";
    }

}
