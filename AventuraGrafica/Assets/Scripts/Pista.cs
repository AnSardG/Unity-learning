using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{
    public int idPista;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameplayManager.instance.DesbloquearPista(idPista);
            Destroy(gameObject);
        }
    }
}
