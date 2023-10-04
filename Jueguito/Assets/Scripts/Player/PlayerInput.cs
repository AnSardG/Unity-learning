using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.OnJumpInputUp();
        }
    }
}
