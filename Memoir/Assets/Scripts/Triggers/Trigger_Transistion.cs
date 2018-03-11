using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trigger_Transistion : MonoBehaviour {

    public Collider2D scene_trigger;
    public string load_scene;
    GameObject player;
    Collider2D player_collider;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player_collider = player.GetComponent<BoxCollider2D>();
        Collider2D trigger = scene_trigger.GetComponent<Collider2D>();
    }

	void Update () {
        if (player_collider.IsTouching(scene_trigger))
        {
            SceneManager.LoadScene(load_scene);
        }
	}
}
