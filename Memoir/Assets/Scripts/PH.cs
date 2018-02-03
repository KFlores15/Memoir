using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PH : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1)){
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		/* if(Input.GetMouseButton(1)){
			Application.LoadLevel(Application.loadedLevel - 1);
		} */

	}
}
