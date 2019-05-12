using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    Rigidbody2D rb;
    float spellDurationTargetTime = 0;


    [Header("Projectile Settings")]
    public float moveSpeed = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spellEffect = new EffectObject(damageValue, waterType, earthType, fireType, airType);
    }

    public override void Constructor(Vector3 castDirection)
    {
        this.castDirection = castDirection;
        spellDurationTargetTime = Time.time + duration;
    }

    void Update()
    {
        rb.velocity = castDirection * moveSpeed;

        if (Time.time >= spellDurationTargetTime) { Destroy(this.gameObject); }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<EnemyBehavior>() != null)
        {
            col.GetComponent<EnemyBehavior>().IncomingEffect(spellEffect);
        }
    }
}
