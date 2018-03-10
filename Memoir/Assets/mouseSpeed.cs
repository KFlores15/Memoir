using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSpeed : MonoBehaviour {

    public float dis;
    public GameObject background, hook;
    public Sprite on, off;
    public int x1, x2, y1, y2;

    private float previousX, previousY, currentX, currentY;
    private bool pressed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1) && Input.mousePosition.x > x1 && Input.mousePosition.x < x2
            && Input.mousePosition.y > y1 && Input.mousePosition.y < y2)
        {
            pressed = true;
            previousX = Input.mousePosition.x;
            previousY = Input.mousePosition.y;
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

            if (Input.GetMouseButtonDown(0))
            {
                //RaycastHit hit = Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log("You selected the " + hit.transform.name);
                    Destroy(hit.collider.gameObject);
                    Item password = new Item("Password Paper", "password", 1, "This is a password for elevator");
                    GameObject.Find("Inventory Manager").GetComponent<InventoryManager>().addItem(password);
                }
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
