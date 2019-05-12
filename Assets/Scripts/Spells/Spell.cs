using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [Header("Spell Settings")]
    public float damageValue = 4.5F;

    public float cooldown = 2.0f;
    public float duration = 2.0f;
    public Vector3 castDirection = new Vector3(0, 0, 0);

    [Header("Effect Settings")]
    public EffectObject spellEffect;
    public bool fireType = false;
    public bool earthType = false;
    public bool waterType = false;
    public bool airType = false;


    void Start()
    {
        spellEffect = new EffectObject(damageValue, waterType, earthType, fireType, airType);
    }

    public abstract void Constructor(Vector3 castDirection);

    void Update()
    {

    }
}
