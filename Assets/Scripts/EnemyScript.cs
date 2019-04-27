using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 moveTarget;
    Vector3 direction;
    
    public float moveSpeed = 1;
    public int maxHP = 10;
    int currentHP;
    // TODO: make array for enemy skills

    public float fireEffectiveness = 1.0f;
    public float earthEffectiveness = 1.0f;
    public float waterEffectiveness = 1.0f;
    public float airEffectiveness = 1.0f;

    public float knockbackEffectiveness = 1.0f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveTarget = new Vector3(0,0);
        direction = new Vector3(0,0);

        currentHP = maxHP;
    }

    void Update()
    {
        direction = moveTarget - transform.position;
        rb.velocity = direction.normalized * moveSpeed;
    }



}
