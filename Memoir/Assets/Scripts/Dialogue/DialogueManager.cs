using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {
	//used for attaching the objects in the hierarchy
	public Text nameText;
	public Text dialogueText;

	public Animator anim; //controls the animation of the dialogue box (open/close)

	private Queue<string> dialogueContent; //holds the dialogue sentences

	// Use this for initialization
	void Start () {
		dialogueContent = new Queue<string>();
	}

	//reads dialogue from inspector window into a queue
	public void StartDialogue(Dialogue dialogue) {
		anim.SetBool("isOpen", true);

		//Can set a speaker name to appear in the dialogue box. If dialogue is meant to be internal we can just set this as "you" or something...
		nameText.text = dialogue.NPCName;

		//clear any existing/leftover dialogue
		dialogueContent.Clear();

		//reads in the dialogue entered in the inspector window into the dialogue queue
		foreach (string sentence in dialogue.textContent) {
			dialogueContent.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	//moves through the sentences of the queue
	public void DisplayNextSentence() {
		//check if there is no more dialogue in the queue
		if(dialogueContent.Count == 0) {
			EndDialogue();
			return;
		}

		//offloads the next sentence from the queue
		string sentence = dialogueContent.Dequeue();
		//dialogueText.text = sentence; //this line will display the entire sentence at once

		//first clear all running coroutines and start a new coroutine to type out the sentence in the dialogue box
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	//coroutine to make each letter of the sentence appear one by one
	IEnumerator TypeSentence(string sentence) {
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.05f);
		}
	}

	//basically just tells the animator to play the closing animation
	void EndDialogue() {
		anim.SetBool("isOpen", false);
		if(SceneManager.GetActiveScene().buildIndex == 3) {
			//GameObject.Find("sunset_scene_trigger").GetComponent<Fade>().enabled = true;
			SceneManager.LoadScene(0);
		}
	}
}
