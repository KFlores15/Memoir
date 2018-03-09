using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class castShadow : MonoBehaviour {
    public GameObject center;
    public GameObject lightSource;
    [Range(1, 25)]
    public int shadowLengthModifier = 10; 
    GameObject anchor;
    private void Start() {
        anchor = new GameObject("anchor");
        anchor.transform.SetParent(transform.parent);
        anchor.transform.position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 distBetween = center.transform.position - lightSource.transform.position;

        Vector3 xShift = new Vector3(distBetween.x/shadowLengthModifier, 0, 0);

        transform.position = anchor.transform.position + xShift; 
	}
}
