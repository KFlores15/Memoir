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

	public AudioClip failSound;
	public AudioClip successSound;
	public AudioSource SoundObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		playerCode += getValue();
		totalDigits++;
		//Debug.Log("Total Digits: " + totalDigits);
		Debug.Log("Player Code: " + playerCode);

		if(totalDigits == 3 && playerCode==correctCode){
			StartCoroutine(puzzleClear());
			playerCode="";
			totalDigits = 0;
			Debug.Log("Correct!");
<<<<<<< HEAD
			SceneManager.LoadScene("StationElevator2");
=======

>>>>>>> 2a419082100d863edbc496ae29f9dca9e01afdd0
		}
		else if (totalDigits == 3) {
			SoundObject.PlayOneShot(failSound);
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

	//allows the 'success' sound effect to play before switching the scene
	IEnumerator puzzleClear() {
		SoundObject.PlayOneShot(successSound);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("StationElevator2");
	}
}
