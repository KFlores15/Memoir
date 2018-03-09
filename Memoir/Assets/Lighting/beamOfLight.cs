using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class beamOfLight : MonoBehaviour {
    public GameObject source;
    public Vector2 sourceOffset = Vector2.zero;
  
    public GameObject target;
    public bool lockTargetToPlane = true;

    public GameObject aura;
    
    [Range(1, 50)]
    public float auraOrigin= 6f;
    [Range(1, 50)]
    public float auraRange = 7.5f;
    public bool auraMatchBeamColor = true;

    private Light beamLight;
    private Light auraLight;

	// Update is called once per frame
	void Update () {
        //would like to happen in editor so don't use Start()!
        beamLight = GetComponent<Light>();
        auraLight = aura.GetComponent<Light>();
        //end of Start()
        
        //keep aura in right place 
        aura.transform.localPosition =  new Vector3(4, 0, auraOrigin);
        auraLight.range = auraRange;

        if(auraMatchBeamColor){
            auraLight.color = beamLight.color;
        }
        
        //keep target on same z plane as light so it stays a tight beam
        if(lockTargetToPlane){
            target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
        //light follow target
        transform.LookAt(target.transform);


        //light stick to source
        if(source != null){
            transform.position = new Vector3(source.transform.position.x + sourceOffset.x,
                                             source.transform.position.y + sourceOffset.y,
                                             transform.position.z);
        }

	}
}
