using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public Renderer rend;
    public GameObject player;
    public Vector2 spawn;
    public int load;
    public bool face_left;

    int timer;
    int bound;

    //private bool follow = true;
    void Start()
    {
        rend = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        rend.enabled = true;

        bound = 50;
        timer = bound;
    }

    // Update is called once per frame
    void Update()
    {
        //Behaviour(follow);
<<<<<<< HEAD
<<<<<<< HEAD
        transform.Translate(Vector2.left * timer / 30 * Time.deltaTime / 2);
=======
        transform.Translate(Vector2.right * timer / 30 * Time.deltaTime / 2);
>>>>>>> 2d66fddedf4291e3bf0202a1cb8bc84f6ffa2be6
=======
        transform.Translate(Vector2.right * timer / 30 * Time.deltaTime / 2);
>>>>>>> 2d66fddedf4291e3bf0202a1cb8bc84f6ffa2be6
        timer--;
        if (timer == 0) timer = bound;
    }

    

    private void Behaviour(bool follow)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        transform.Translate(Vector2.left * (4/2) * Time.deltaTime / 2);
=======
        transform.Translate(Vector2.right * (4/2) * Time.deltaTime / 2);
>>>>>>> 2d66fddedf4291e3bf0202a1cb8bc84f6ffa2be6
=======
        transform.Translate(Vector2.right * (4/2) * Time.deltaTime / 2);
>>>>>>> 2d66fddedf4291e3bf0202a1cb8bc84f6ffa2be6
        Debug.Log("Attempting to follow player");
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
		{
			Debug.Log("Colided with player");
            //StartCoroutine(Wait());
            Destroy(gameObject);
            SceneManager.LoadScene(load);
            player.transform.position = spawn;

<<<<<<< HEAD
<<<<<<< HEAD
            player.transform.localScale = new Vector3(face_left ? 1 : -1, 1, 1);
=======
            player.transform.localScale = new Vector3(face_right ? 1 : -1, 1, 1);
>>>>>>> 2d66fddedf4291e3bf0202a1cb8bc84f6ffa2be6
=======
            player.transform.localScale = new Vector3(face_right ? 1 : -1, 1, 1);
>>>>>>> 2d66fddedf4291e3bf0202a1cb8bc84f6ffa2be6
        }
	}

	//waits for fade and then destroys monster and 'kills' the friend
	IEnumerator Wait()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		Destroy(gameObject);
        SceneManager.LoadScene(load);
		player.transform.position = spawn;

        player.transform.localScale = new Vector3(face_left ? 1 : -1 , 1, 1);
    }
}
