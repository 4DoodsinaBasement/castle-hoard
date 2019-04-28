using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 moveTarget;
    Vector3 moveDirection;
    
    [Header("Movement & HP")]
    public float moveSpeed = 1;
    public int maxHP = 10;
    public int currentHP;
    // TODO: make array for enemy skills

    [Header("Elemental Resistences")]
    public float fireEffectiveness = 1.0f;
    public float earthEffectiveness = 1.0f;
    public float waterEffectiveness = 1.0f;
    public float airEffectiveness = 1.0f;

    public float knockbackEffectiveness = 1.0f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTarget = new Vector3(0,0);
        moveDirection = new Vector3(0,0);

        currentHP = maxHP;
    }

    void Update()
    {
        moveDirection = moveTarget - transform.position;
        rb.velocity = moveDirection.normalized * moveSpeed;

        if (currentHP <= 0) { Destroy(this.gameObject); }
    }


    public void IncomingEffect(EffectObject incommingEffect)
    {
        currentHP -= (int)incommingEffect.damage;
    }
}
