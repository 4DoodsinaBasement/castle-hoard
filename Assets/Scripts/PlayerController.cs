using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public enum PlayerID { Player1 = 0, Player2 = 1, Player3 = 2, Player4 = 3 }

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public PlayerID playerID;
    Player player;
    public float moveSpeed = 0.0f;
    Rigidbody2D rb;
    Vector3 moveDirection = new Vector3(0, 0, 0);
    Vector3 lookDirection = new Vector3(0, 1, 0);
    public GameObject spellToCast;
    float spellCooldownTargetTime = 0;

    void Start()
    {
        player = ReInput.players.GetPlayer((int)playerID);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.GetButton("Cast Spell 1") && SpellIsReady()) { CastSpell(); }
        PlayerMove();
        PlayerLook();
    }
    
    void PlayerMove()
    {
        moveDirection.x = player.GetAxis("Move Horizontal");
        moveDirection.y = player.GetAxis("Move Vertical");
        rb.velocity = moveDirection * moveSpeed;
    }

    void PlayerLook()
    {
        if (!player.GetButton("Strafe") && !(moveDirection.x == 0 && moveDirection.y == 0)) { lookDirection = moveDirection; }
        transform.rotation = Quaternion.AngleAxis((Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg), Vector3.forward);
    }

    void CastSpell()
    {
        GameObject spellObject = Instantiate(spellToCast, transform.position, Quaternion.identity);
        spellObject.GetComponent<Spell>().Constructor(lookDirection.normalized);
        spellCooldownTargetTime = Time.time + spellToCast.GetComponent<Spell>().cooldown;
    }

    bool SpellIsReady()
    {
        return (Time.time >= spellCooldownTargetTime);
    }
}
