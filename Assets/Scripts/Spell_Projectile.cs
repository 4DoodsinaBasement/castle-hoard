using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Projectile : Spell_Generic
{
    [Header("Projectile Settings")]
    public float moveSpeed = 1f;

    EffectObject spellEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        spellEffect = new EffectObject(baseDamage, isWater, isEarth, isFire, isAir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Vector3 moveTarget)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyBehavior>().IncomingEffect(spellEffect);
    }
}
