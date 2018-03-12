using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public int load;
    public Vector2 spawn;
    public bool face_right;
    public bool change_sprite;
    public bool unlocked = true;
    public bool player_exists_in_next_room;
    private Fade fade;
    private string locked_name;
    private string temp;

    void Awake()
    {
        fade = gameObject.AddComponent<Fade>();
        locked_name = this.name_of_object + "(Locked)";
        temp = this.name_of_object;
    }

    public override void Interact()
    {
        if (unlocked)
        {
            this.name_of_object = temp;
            if (player_exists_in_next_room)
            {
                SceneManager.LoadScene(load);
				//SceneManager.LoadSceneAsync(load);
				if (change_sprite)
				{
					SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
					renderer.color = (renderer.color == Color.white ? Color.black : Color.white);
				}
				player.transform.position = spawn;
				player.transform.localScale = new Vector3(face_right ? 1 : -1, 1, 1);
            }
            else
            {
                StartCoroutine(FadeLevel());
            }
        }

        if (!unlocked)
        {
            this.name_of_object = locked_name;
        }
    }

    IEnumerator FadeLevel()
    {
        float fade_time = fade.BeginFade(3);
        Debug.Log(fade_time);
        player.GetComponent<PlayerMovementController>().enabled = false;

        yield return new WaitForSeconds(fade_time);

        player.GetComponent<PlayerMovementController>().enabled = true;
    }
}