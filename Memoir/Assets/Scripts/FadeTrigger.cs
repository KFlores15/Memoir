using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTrigger : Interactable {
	public Fade fade;
	//public GameObject player;

	void Start() {
		fade = gameObject.AddComponent<Fade>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
		
	public override void Interact() {
		StartCoroutine(FadeLevel());
	}

	IEnumerator FadeLevel() {
		Debug.Log("Attempting to fade level");
		float fade_time = fade.BeginFade(1);
		Debug.Log(fade_time);

		//halt player movement until fade is done
		player.GetComponent<PlayerMovementController>().enabled = false;
		yield return new WaitForSeconds(fade_time);
		player.GetComponent<PlayerMovementController>().enabled = true;
	}
}
