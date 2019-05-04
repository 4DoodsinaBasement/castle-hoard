using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove(SimulateJoystick());
    }

    Vector2 SimulateJoystick()
    {
        Vector2 moveDirection = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += new Vector2(1, 0);
        }

        return moveDirection;
    }



    void PlayerMove(Vector2 moveDirection)
    {
        rb.velocity = moveDirection * moveSpeed;


        Debug.Log(moveDirection);

    }
}
