using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//this class is purely to create a space in the inspector to enter the strings of dialogue text to be used later by the dialogue manager
public class Dialogue {

	public string NPCName; //name of the speaker
	[TextArea(3, 10)] //specifies the size of the input field in the inspector window; syntax: (minimum number of lines, maximum number of lines) 
	public string[] textContent; //string array to hold all the dialogue strings
}
