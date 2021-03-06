﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public Renderer rend;
    public GameObject player;
    public Vector2 spawn;
    public int load;
    public bool face_right;

    private bool follow = true;
    void Start()
    {
        rend = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Behaviour(follow);
    }

    

    private void Behaviour(bool follow)
    {
            transform.Translate(Vector2.right * (4/2) * Time.deltaTime / 2);
            Debug.Log("Attempting to follow player");
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
		{
			Debug.Log("Colided with player");
			StartCoroutine(Wait());
}
	}

	//waits for fade and then destroys monster and 'kills' the friend
	IEnumerator Wait()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		Destroy(gameObject);
        SceneManager.LoadScene(load);
		player.transform.position = spawn;

        player.transform.localScale = new Vector3(face_right ? 1 : -1 , 1, 1);
    }
}
