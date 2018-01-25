using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public float walkSpeed = 1;
	public float runSpeed = 2;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// FixedUpdate is recommended for animation
	void FixedUpdate () {
		//get horizontal input (A or D on keyboard) and multiply by a set walk speed defined above
		if(Input.GetKey(KeyCode.LeftShift) == false) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, 0);
		}
		else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0);
		}
		/*****************************OLD***************************/
			//set the animation parameter defined as "hSpeed" to the velocity which will transition the sprite mode from "Idle" to "WriterWalking"
			//anim.SetFloat("hSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		/**********************************************************/
		//check if character is moving and tell animator to change state
		if(GetComponent<Rigidbody2D>().velocity.x != 0 && Input.GetKey(KeyCode.LeftShift) == false) {
			anim.SetBool("isWalking", true);
		}
		else {
			anim.SetBool("isWalking", false);
		}
		if(GetComponent<Rigidbody2D>().velocity.x != 0 && Input.GetKey(KeyCode.LeftShift) == true) {
			anim.SetBool("isRunning", true);
		}
		else {
			anim.SetBool("isRunning", false);
		}

		//check for movement in the -x or +x direction to then accordingly flip the sprite horizontally to get proper bi-directional sprite movement
		if(GetComponent<Rigidbody2D>().velocity.x > 0 && transform.localScale.x < 0) {
			transform.localScale = new Vector3(1, 1, 1);
		}
		if(GetComponent<Rigidbody2D>().velocity.x < 0 && transform.localScale.x > 0) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}
}
