using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    private PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            player.cCheck.left = player.dCheck.left;
            player.cCheck.right = player.dCheck.right;
            player.cCheck.up = player.dCheck.up;
            player.cCheck.down = player.dCheck.down;

            //switch (player.dCheck)
            //{
            //    case dCheck.:
            //        collision.gameObject.GetComponent<PlayerController>().cCheck.left = true;
            //        break;
            //    case "Right":
            //        collision.gameObject.GetComponent<PlayerController>().cCheck.right = true;
            //        break;
            //    case "Up":
            //        collision.gameObject.GetComponent<PlayerController>().cCheck.up = true;
            //        break;
            //    case "Down":
            //        collision.gameObject.GetComponent<PlayerController>().cCheck.down = true;
            //        break;
            //}

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().cCheck.ResetCollisions();
        }
    }

}
