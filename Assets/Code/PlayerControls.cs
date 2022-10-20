using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float Speed;
    public float Health = 1;
    public GameObject Player;
    public Rigidbody2D Rigidbody;
    public float Jump;
    public Rigidbody2D Deathwall;
    public EnemyManager EManager;
    private float AttackCharge = 0;
    public Transform SpellSummon;
    public GameObject PlayerSpell;
    public float SpellSpeed = 0.01f;
    public GameObject SpellClone;

    void Start()
    {
        Vector3 SpawnPosition = new Vector3(-6.9f, -4.42f, 0f);
        transform.position = SpawnPosition;
    }
    private void LateUpdate()
    {
        SpellClone = GameObject.FindGameObjectWithTag("PlayerSpell");
    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        Vector2 newPosition = gameObject.transform.position;

        newPosition.x += xMove * Speed * Time.deltaTime;

        transform.position = newPosition; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            Jump = 0;
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
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (AttackCharge == 0)
            {
                AttackCharge += 1;
                Debug.Log("1!");
            }
            else
            { 
                AttackCharge = 0; 
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (AttackCharge == 1)
            {
                AttackCharge += 1;
                Debug.Log("2!");

            }
            else
            {
                AttackCharge = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (AttackCharge == 2)
            {
                Instantiate(PlayerSpell, SpellSummon.position, SpellSummon.rotation);
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Rigidbody.velocity = Vector3.left * SpellSpeed;
                    Invoke("DestroySpell", 2);
                }
                else
                {
                    Rigidbody.velocity = Vector3.right * SpellSpeed;
                    Invoke("DestroySpell", 2);
                }
            }
            AttackCharge = 0;
        }
    }

    private void DestroySpell()
    {
        Destroy(SpellClone);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CrystalSpike")
        {
            SceneManager.LoadScene(3);

        }
        if (collision.gameObject.tag == "Deathwall")
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
            EManager.EnemySpawn(collision.gameObject.GetComponent<Spawner>().SpawnPosition.position);
        }
    } 
    void JumpReset()
    {
        Jump = 8;
    }
}
