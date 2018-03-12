using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public float walkSpeed;
	public float runSpeed;
	Animator anim;
    GameObject player;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		walkSpeed = 0.6f;
		runSpeed = 1.8f;
		anim = GetComponent<Animator>();
        player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        GameObject.DontDestroyOnLoad(player);
    }
		
	// FixedUpdate is recommended for animation
	void FixedUpdate () {
		//get horizontal input (A or D on keyboard) and multiply by a set walk speed defined above
		if(Input.GetKey(KeyCode.LeftShift) == false) {
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, 0);
		}
		else {
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0);
		}
		//check if character is moving and tell animator to change state
		if(rb.velocity.x != 0 && Input.GetKey(KeyCode.LeftShift) == false) {
			anim.SetBool("isWalking", true);
		}
		else {
			anim.SetBool("isWalking", false);
		}
		if(rb.velocity.x != 0 && Input.GetKey(KeyCode.LeftShift) == true) {
			anim.SetBool("isRunning", true);
		}
		else {
			anim.SetBool("isRunning", false);
		}

		//check for movement in the -x or +x direction to then accordingly flip the sprite horizontally to get proper bi-directional sprite movement
		if(rb.velocity.x > 0 && transform.localScale.x < 0) {
			transform.localScale = new Vector3(1, 1, 1);
		}
		if(rb.velocity.x < 0 && transform.localScale.x > 0) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}
}
