using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSpeed : MonoBehaviour {

    public float dis;
    public GameObject background, hook;
    public Sprite on, off;

    private float previousX, previousY, currentX, currentY;
    private bool pressed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) && Input.mousePosition.x > 355 && Input.mousePosition.x < 375
            && Input.mousePosition.y > 295 && Input.mousePosition.y < 310)
        {
            pressed = true;
            previousX = Input.mousePosition.x;
            previousY = Input.mousePosition.y;
            Debug.Log('1');
        }

        if (Input.GetMouseButtonUp(1))
            pressed = false;

        if (pressed)
        {
            background.GetComponent<SpriteRenderer>().sprite = on;
            currentX = Input.mousePosition.x;
            currentY = Input.mousePosition.y;

            if (hook.transform.position.y > 0)
                hook.transform.Translate(0, -0.01f, 0);

            if (Mathf.Abs(currentX - previousX) > dis || Mathf.Abs(currentY - previousY) > dis)
                pressed = false;
            else
            {
                previousX = currentX;
                previousY = currentY;
            }

        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = off;

            if (hook.transform.position.y < 0.74)
                hook.transform.Translate(0, 0.01f, 0);
        }
    }
}
