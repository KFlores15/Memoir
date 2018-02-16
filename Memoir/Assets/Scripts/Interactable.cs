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

    void OnMouseDown()
    {
        if (player_collider.IsTouching(interactable_collider))
        {
            Interact();
        }
    }

    public virtual void Interact() { 
	}
}
