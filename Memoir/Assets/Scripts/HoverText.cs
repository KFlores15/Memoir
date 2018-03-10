using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverText : MonoBehaviour {
	public GameObject player;
	public Text txt;
	public Vector3 offset;
	public static bool displayText;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		txt.GetComponent<Text>().enabled = false;
		displayText = false;
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Camera.main.WorldToScreenPoint(player.transform.position) + offset;

		if (displayText) {
			txt.text = "Press 'space' to use door";
			txt.GetComponent<Text>().enabled = true;
		}
		else {
			txt.GetComponent<Text>().enabled = false;
		}
			
	}
}
