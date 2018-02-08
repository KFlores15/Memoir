using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : Interactable {
    public int load;
    public Vector2 spawn;
    public bool face_right;
    public bool change_sprite;

    public bool player_exists_in_next_room;
    public GameObject player;
    private Fade fade;

    void Start()
    {
        fade = gameObject.AddComponent<Fade>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {
        if (player_exists_in_next_room)
        {
            SceneManager.LoadSceneAsync(load);
        }
        else
        {
            StartCoroutine(FadeLevel());
        }
    }

    IEnumerator FadeLevel()
    {
        Debug.Log("Attempting to fade level");
        float fade_time = fade.BeginFade(1);
        Debug.Log(fade_time);
        player.GetComponent<PlayerMovementController>().enabled = false;

        yield return new WaitForSeconds(fade_time);

        player.GetComponent<PlayerMovementController>().enabled = true;
        SceneManager.LoadSceneAsync(load);
        if (change_sprite)
        {
            SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
            renderer.color = (renderer.color == Color.white ? Color.black : Color.white);
        }
        player.transform.position = spawn;
        player.transform.localScale = new Vector3(face_right ? 1 : -1, 1, 1);
    }
}
