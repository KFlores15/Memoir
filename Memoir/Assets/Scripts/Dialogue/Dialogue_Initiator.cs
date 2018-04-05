using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Initiator : MonoBehaviour {
	void Start() {
		GetComponent<DialogueTrigger>().TriggerDialogue();
	}
}
