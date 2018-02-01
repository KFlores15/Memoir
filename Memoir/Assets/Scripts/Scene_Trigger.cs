using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Trigger : MonoBehaviour {

    public GameObject player;
    public Collider2D player_collider;
    public Collider2D trigger_collider;

    public SpriteRenderer background;
    public Sprite cutscene;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_collider = player.GetComponent<BoxCollider2D>();
        trigger_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        if (player != null && player_collider.IsTouching(trigger_collider))
        {
            Destroy(player_collider);
            Destroy(player);
            background.sprite = cutscene;
        }
	}
}
