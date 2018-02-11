using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnStart : MonoBehaviour {
    public bool SetActive;
    
	// Use this for initialization
	void Start () {
        gameObject.SetActive(SetActive);
	}
	
}
