using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PH : Interactable {
    public int load;
    public Vector2 spawn;
    public bool face_right;
    public bool change_sprite;

    public override void Interact()
    {
        SceneManager.LoadScene(load);
        if(change_sprite)
        {
            SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
            renderer.color = (renderer.color == Color.white ? Color.black : Color.white);
        }
		StartCoroutine(waitForLoad());
		player.transform.position = spawn;

		player.transform.localScale = new Vector3(face_right ? 1 : -1 , 1, 1);
        
    }

	IEnumerator waitForLoad() {
		yield return new WaitForSecondsRealtime(0.5f);
		Add_Player();
	}

	void Add_Player()
	{
		
	}
}
