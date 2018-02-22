using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : MonoBehaviour {

	public Transform canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void update(){
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(canvas.gameObject.activeInHierarchy == false)
			{
				canvas.gameObject.SetActive(true);
			}else
			{
				canvas.gameObject.SetActive(false);
			}
		}
	}
}
