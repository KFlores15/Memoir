using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	public static string correctCode="397";
	public static string playerCode = "";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (playerCode);

	}

	void OnMouseUp()
	{
		playerCode += gameObject.name;
		totalDigits += 1;
	}
	
}
