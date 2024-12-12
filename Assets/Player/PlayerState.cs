using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : LivingCreature
{
    public PlayerMove playerMove;
    public GameObject playertrigger;

    public float MoveSpeed;
    public float BaseDamage;
    public float currentDamage;

    public int MaxHealthP;
    public int currentHealthP;

    public bool isMove;
    public bool isGround;

    Animator animator;

    public override void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animationsynchronization();
    }
    public override void Damaged(float damage)
    {
        HealthPM(damage);
        StartCoroutine(Invincibility());
        Debug.Log("Damaged");
    }
    IEnumerator Invincibility()
    {
        playertrigger.layer = LayerMask.NameToLayer("Dodge");
        yield return new WaitForSeconds(1);
        playertrigger.layer = LayerMask.NameToLayer("LivingCreature");
    }
    public override void HealthPM(float damage)
    {
        currentHealthP --;
        if (currentHealthP <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        Dead = true;
        gameObject.SetActive(false);
    }
    void Animationsynchronization()
    {
        animator.SetBool("isGround", isGround);
        animator.SetBool("isMove", isMove);
    }
}
