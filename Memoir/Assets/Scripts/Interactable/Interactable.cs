using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public Collider2D interactable_collider;
    public GameObject player;
    public Collider2D player_collider;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_collider = player.GetComponent<BoxCollider2D>();
    }

	//check if player is colliding with the door hitbox
	//triggers the text script component of the text object on/off 
	void Update() {
		if (player_collider.IsTouching(interactable_collider))
		{
			openDoor();
			HoverText.displayText = true;
		}
		else {
			HoverText.displayText = false;
		}

	}

	//only enables interaction when called
	void openDoor() {
		if(Input.GetKeyDown("space")) {
			Interact();
		}
	}
		
	/*
    void OnMouseDown()
    {
        if (player_collider.IsTouching(interactable_collider))
        {
            Interact();
        }
    }
    */

    public virtual void Interact() { 
	}
}
