using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellControls : MonoBehaviour
{
    public float SpellSpeed = 10;
    public Rigidbody2D SpellRB;
    public GameObject SpellClone;
    public GameObject PlayerSpell;
    private float AttackCharge = 0;
    public Transform SpellSummon;

    private void LateUpdate()
    {
            SpellClone = GameObject.FindGameObjectWithTag("PlayerSpell");
    }
    void Update()
    {
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
                SpellRB.velocity = Vector3.right * SpellSpeed;
                InvokeRepeating("DestroySpell", 0, 5);
            }
            AttackCharge = 0;
        }
    }
    private void DestroySpell()
    {
    Destroy(SpellClone);
    }

}
