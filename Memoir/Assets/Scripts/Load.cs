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
            Add_Player();
            SceneManager.LoadScene("Motel Room");
        }
    }

    void Add_Player()
    {
        Instantiate(player, new Vector3(-0.46f, -0.23f, 0f), Quaternion.identity);
    }
}
