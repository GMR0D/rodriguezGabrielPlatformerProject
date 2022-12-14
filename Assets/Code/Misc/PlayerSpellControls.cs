using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellControls : MonoBehaviour
{
    public float SpellSpeed = 10;
    public GameObject SpellClone;
    public GameObject PlayerSpell;
    private float AttackCharge = 0;
    private float SpellRecharge = 0;
    public Transform SpellSummon;
    public Animator SpellAnimator;
    private int SpellUpdate;
    private AudioSource SpellAudio;

    private void Start()
    {
        SpellAudio = GetComponent<AudioSource>();
    }
    private void LateUpdate()
    {
            SpellClone = GameObject.FindGameObjectWithTag("PlayerSpell");
    }
    void Update()
    {
        SpellAnimator.SetInteger("Spell", SpellUpdate);
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (AttackCharge == 0 && (SpellRecharge == 0))
            {
                AttackCharge += 1;
                SpellUpdate = 1;
                Debug.Log("1!");
            }
            else
            {
                AttackCharge = 0;
                SpellUpdate = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (AttackCharge == 1)
            {
                AttackCharge += 1;
                SpellUpdate = 2;
                Debug.Log("2!");

            }
            else
            {
                AttackCharge = 0;
                SpellUpdate = 0;

            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (AttackCharge == 2)
            {
                SpellUpdate = 3;
                GameObject PlayersSpell = Instantiate(PlayerSpell,SpellSummon.position,Quaternion.identity);
                PlayersSpell.GetComponent<Rigidbody2D>().velocity = Vector3.right * SpellSpeed;
                SpellAudio.Play();
                SpellRecharge = 1;
                Invoke("DestroySpell", 2);
                Invoke("SpellCharge", 0.4f);
            }
            AttackCharge = 0;
            SpellUpdate = 0;
        }
    }
    private void DestroySpell()
    {
    Destroy(SpellClone);
    }
    private void SpellCharge()
    {
        SpellRecharge = 0;
    }

}
