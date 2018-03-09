using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			StartCoroutine(waitForLoad());
            
        }
    }

	IEnumerator waitForLoad() {
		yield return new WaitForSecondsRealtime(0.5f);
		SceneManager.LoadScene("Motel Room");
		//yield return new WaitForSecondsRealtime(1);
		Add_Player();
	}

   	void Add_Player()
    {
		Instantiate(player, new Vector3(-0.46f, -0.23f, 0f), Quaternion.identity);
    }
}
