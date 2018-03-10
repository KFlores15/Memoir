using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpaceCutscne1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Add_Player();
            SceneManager.LoadScene("MonsterLab");
        }
    }

    /*void Add_Player()
    {
		Instantiate(player, new Vector3(-0.46f, -0.23f, 0f), Quaternion.identity);
    }*/
}
