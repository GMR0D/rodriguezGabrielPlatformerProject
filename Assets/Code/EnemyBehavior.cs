using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnerActivation;
    public GameObject Hexer;
    public Transform SpellSummon;
    public GameObject EnemySpell;
    public GameObject PlayerSprite;
    public Transform EnemySpawnPos;

    public float Speed = 0.1f;
    private void LateUpdate()
    {
        PlayerSprite = GameObject.FindGameObjectWithTag("Player");
    }

    public void EnemySpawn()
    {
        InvokeRepeating("Spellcasting", 2, 3);
    }
    private void Spellcasting()
    {
        GameObject NewEnemySpell = Instantiate(EnemySpell, transform.position, Quaternion.identity);
        Vector2 velocity = PlayerSprite.transform.position - transform.position;
        velocity.Normalize();
        NewEnemySpell.GetComponent<Rigidbody2D>().AddForce(Speed * velocity * Time.deltaTime, ForceMode2D.Impulse);
        Destroy(NewEnemySpell, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerSpell")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}


