using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Collider2D interactable_collider;
    public GameObject player;
    public Collider2D player_collider;
    public string name_of_object;
    public string instruction;
	public bool isDoor;

    private Rect interactable_overhead;
    private Rect under_overhead;
    private Vector3 over_interactable = new Vector3(0, 0, 0);
    private Vector3 under_interactable = new Vector3(0, 0, 0);
    private GUIStyle label_style;
    void Start()
    {
        // Find Player
        player = GameObject.FindGameObjectWithTag("Player");
        player_collider = player.GetComponent<BoxCollider2D>();

        //Modify the rectangle so that GUI can use it properly
        interactable_overhead.size = new Vector2(100, 100);
        under_overhead.size = new Vector2(100, 100);
        //Create an empty style for the text
        label_style = GUIStyle.none;
        label_style.alignment = TextAnchor.UpperCenter;
        label_style.normal.textColor = Color.white;

        // Find GUI position over the door
        if (interactable_collider != null)
        {
            over_interactable = new Vector3(interactable_collider.transform.position.x, interactable_collider.transform.position.y + interactable_collider.bounds.size.y / 2, interactable_collider.transform.position.z);
			under_interactable = new Vector3(interactable_collider.transform.position.x, (interactable_collider.transform.position.y + interactable_collider.bounds.size.y / 2) - 0.08f, interactable_collider.transform.position.z);
        }
        Vector3 new_center = Camera.main.WorldToScreenPoint(over_interactable);
        Vector3 under_center = Camera.main.WorldToScreenPoint(under_interactable);

        new_center.y = Screen.height - new_center.y;
        under_center.y = Screen.height - under_center.y;
        interactable_overhead.center = new_center;
        under_overhead.center = under_center;

		//Instruction
		if(isDoor) {
			instruction = "(E)";
		}
    }
    void Update()
    {
        if (player == null) return;

        if (player_collider.IsTouching(interactable_collider) && Input.GetKeyDown(KeyCode.E) == true)
        {
            Interact();
            Debug.Log("Interaction Called through keyboard!");
        }
    }

    private void OnGUI()
    {
        if (player == null) return;

        if (player_collider.IsTouching(interactable_collider))
        {
            GUI.Label(interactable_overhead, name_of_object, label_style);
            GUI.Label(under_overhead, instruction, label_style);
        }
    }
		
    void OnMouseDown()
    {
        if (player_collider.IsTouching(interactable_collider))
        {
            Interact();
        }
    }
    
    public virtual void Interact() { }
}
