using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	//this class allows the specification of specific dialogue trigger objects in the inspector window (this can be an NPC, world object, etc.)
	public void TriggerDialogue() {
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}
