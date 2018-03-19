using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantMarble : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown(){
		Destroy(gameObject);
		SceneManager.LoadScene("StationWindow");
	}


}
