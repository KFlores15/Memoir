using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour {

	public static string correctCode="397";
	private string playerCode = "";
	private int totalDigits = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerCode += getValue();
		totalDigits++;
		Debug.Log("Player Code: " + playerCode);

		if(totalDigits == 3 && playerCode==correctCode){
			playerCode="";
			totalDigits = 0;
			Debug.Log("Correct!");
			SceneManager.LoadScene("StationElevator2");
		}
		else if (totalDigits == 3) {
			playerCode="";
			totalDigits = 0;
			Debug.Log("Incorrect!");
		}
	}

	string getValue() {
		string buttonPushed;
		buttonPushed = EventSystem.current.currentSelectedGameObject.name;
		EventSystem.current.SetSelectedGameObject(null);
		//Debug.Log(buttonPushed);
		return buttonPushed;
	}
}
