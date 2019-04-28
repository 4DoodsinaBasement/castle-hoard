using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject
{
    public float damage;
    public bool isWater, isEarth, isFire, isAir;
    
    public EffectObject (float dmg, bool water, bool earth, bool fire, bool air)
    {
        damage = dmg;
        
        isWater = water;
        isEarth = earth;
        isFire = fire;
        isAir = air;
    }
}
