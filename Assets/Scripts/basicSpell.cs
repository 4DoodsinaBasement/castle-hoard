using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicSpell : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 moveTarget;
    Vector3 moveDirection;
    EffectObject effect;
    public float damageValue = 4.5F;
    public bool FireType = false;
    public bool EarthType = false;
    public bool WaterType = false;
    public bool AirType = false;

    public int existance = 1000;
    public float moveSpeed = 1;
    public int Cooldown = 500;

    // Start is called before the first frame update
    void Start()
    {
        effect = new EffectObject(damageValue, WaterType, EarthType, FireType, AirType);

        rb = GetComponent<Rigidbody2D>();
        Vector3 spellLocation = new Vector3(0, 0, 0);
        spellLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveTarget = new Vector3(3000 *spellLocation.x , 3000*spellLocation.y);
        moveDirection = new Vector3(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveTarget - transform.position;
        rb.velocity = moveDirection.normalized * moveSpeed;

        if (existance <= 0) { Destroy(this.gameObject); }
        else {
            existance--;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        col.GetComponent<EnemyBehavior>().IncomingEffect(effect);
    }
}
