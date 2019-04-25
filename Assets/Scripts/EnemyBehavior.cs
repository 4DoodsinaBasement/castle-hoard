using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 1;
    Vector3 target = new Vector3(0,0);
    public Vector3 direction = new Vector3(0,0);
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = target - transform.position;
        rb.velocity = direction.normalized * speed;
    }
}
