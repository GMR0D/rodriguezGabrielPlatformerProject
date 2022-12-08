using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colosseum : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(10);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}