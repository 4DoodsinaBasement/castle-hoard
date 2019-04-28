using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    public bool isWater;
    public bool isEarth;
    public bool isFire;
    public bool isAir;

    public float cooldown = 0f;
    public float baseDamage = 0f;
    public float knockback = 0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I found a thing!");
    }
}
