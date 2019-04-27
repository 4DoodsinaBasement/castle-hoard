using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public bool isWater;
    public bool isEarth;
    public bool isFire;
    public bool isAir;

    public float cooldown = 0;
    public float baseDamage = 0;
    public float knockback = 0;
    
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
