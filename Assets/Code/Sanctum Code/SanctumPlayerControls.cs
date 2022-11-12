using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanctumPlayerControls : MonoBehaviour
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
        Vector3 SpawnPosition = new Vector3(-6.9f, -4.42f, 0f);
        transform.position = SpawnPosition;
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        Vector2 newPosition = gameObject.transform.position;

        newPosition.x += xMove * Speed * Time.deltaTime;

        transform.position = newPosition;

        MyAnimator.SetInteger("Xmove", Mathf.RoundToInt(xMove));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            Jump = 0;
            CanJump = false;
            Invoke("JumpReset", 1.2f);
        }
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            Speed = 0.25f;
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            Speed = 0.25f;
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
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deathwall")
        {
            SceneManager.LoadScene(8);
        }
        if (collision.gameObject.tag == "EnemySpell")
        {
            SceneManager.LoadScene(8);
        }
        if (collision.gameObject.tag == "Hexer")
        {
            SceneManager.LoadScene(8);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnerActivation")
        {
            EBehavior.EnemySpawn();
        }
        if (collision.gameObject.tag == "ExitPortal")
        {
            SceneManager.LoadScene(0);
        }
    }
    void JumpReset()
    {
        Jump = 8f;
        CanJump = true;
    }
}