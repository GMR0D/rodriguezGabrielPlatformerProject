using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MtPlayerControls : MonoBehaviour
{
    public float speed;
    public float health = 1;
    public GameObject player;
    public Rigidbody2D Rigidbody;
    public float jump;
    public Rigidbody2D deathwall;
    public EnemyBehavior eBehavior;
    public GameObject exitPortal;
    public bool canJump;
    public Animator myAnimator;
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

        newPosition.x += xMove * speed * Time.deltaTime;

        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                Rigidbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                jump = 0;
                canJump = false;
                Invoke("JumpReset", 1.2f);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            speed = 7;
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            speed = 7;
       }
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            speed = 5;
        }
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            speed = 5;
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
        jump = 9.5f;
        canJump = true;
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
            eBehavior.EnemySpawn();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ExitPortal")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "SecretPortal")
        {
            SceneManager.LoadScene(9);
        }
    }
}
