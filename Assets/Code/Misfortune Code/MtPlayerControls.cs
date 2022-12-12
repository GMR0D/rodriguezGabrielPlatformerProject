using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MtPlayerControls : MonoBehaviour
{
    public float Speed;
    public float Health = 1;
    public GameObject Player;
    public Rigidbody2D Rigidbody;
    public float Jump;
    public Rigidbody2D Deathwall;
    public EnemyBehavior EBehavior;
    public GameObject ExitPortal;
    public bool CanJump;
    public Animator MyAnimator;
    void Start()
    {
        Vector3 SpawnPosition = new Vector3(-7.2f, -3.2f, 0f);
        transform.position = SpawnPosition;

        GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().StopMusic();
    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        Vector2 newPosition = gameObject.transform.position;

        newPosition.x += xMove * Speed * Time.deltaTime;

        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanJump)
            {
                Rigidbody.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                Jump = 0;
                CanJump = false;
                Invoke("JumpReset", 1.2f);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            Speed = 7;
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            Speed = 7;
       }
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            Speed = 5;
        }
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Speed = 5;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(10);
            GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void JumpReset()
    {
        Jump = 9.5f;
        CanJump = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Deathwall2")
        {
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.tag == "EnemySpell")
        {
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.tag == "Hexer")
        {
            SceneManager.LoadScene(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnerActivation")
        {
            EBehavior.EnemySpawn();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ExitPortal")
        {
            SceneManager.LoadScene(10);
        }
        if (collision.gameObject.tag == "SecretPortal")
        {
            SceneManager.LoadScene(8);
        }
    }
}
