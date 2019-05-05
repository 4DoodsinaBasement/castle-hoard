using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public enum PlayerID {Player1 = 0, Player2 = 1, Player3 = 2, Player4 = 3}

public class PlayerInput : MonoBehaviour
{
    [Header("Player Settings")]
    public PlayerID playerID;
    Player player;

    [Header("Character Settings")]
    public float moveSpeed = 0.0f;
    Rigidbody2D rb;
    Vector2 moveDirection = new Vector2(0,0);

    
    void Start()
    {
        player = ReInput.players.GetPlayer((int)playerID);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection.x = player.GetAxis("Move Horizontal");
        moveDirection.y = player.GetAxis("Move Vertical");

        PlayerMove(moveDirection);
    }


    void PlayerMove(Vector2 dir)
    {
        rb.velocity = dir * moveSpeed;
    }
}
