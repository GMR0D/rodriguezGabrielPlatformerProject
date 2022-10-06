using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Speed;
    public float Health = 1;
    public GameObject Player;
    public Rigidbody2D Rigidbody;
    public float Jump;
    public Rigidbody2D Deathwall;
    void Update()
    {
        //PRINT COLLISION LINES FOR MILESTONE!

        float xMove = Input.GetAxis("Horizontal");

        Vector2 newPosition = gameObject.transform.position;

        newPosition.x += xMove * Speed * Time.deltaTime;

        transform.position = newPosition; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            Jump = 0;
            Invoke("JumpReset", 1);
        }
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            Speed = 0.35f;
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            Speed = 0.35f;
        }
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            Speed = 5;
        }
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Speed = 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //Why aren't you working..?
    {
        if (collision.gameObject.tag == "Deathwall")
        {
            Vector3 SpawnPosition = new Vector3(-6.9f, -4.42f, 0f);
            transform.position = SpawnPosition;
        }
    }
    void JumpReset()
    {
        Jump = 8;
    }
}
