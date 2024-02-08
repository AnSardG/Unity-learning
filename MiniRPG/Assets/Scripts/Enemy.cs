using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Public VARS
    public enum TipoEnemigo { Fijo, Movil }

    public TipoEnemigo tipoEnemigo;
    public int enemyHealth, enemyDamage;
    public float velocidad = .2f;

    // REFERENCES
    public Transform waypointA, waypointB;
    public Animator anim;

    // Private VARS
    private Transform objetivo;
    private bool alive = true;

    
    void Start()
    {
        objetivo = waypointB;
        velocidad /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(tipoEnemigo == TipoEnemigo.Movil && alive)
        {
            // Calcular la dirección y la distancia hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Mover al enemigo hacia el objetivo
            transform.position += direccion * velocidad * Time.deltaTime;

            // Si el enemigo llega al objetivo, cambiar el objetivo
            if (Vector3.Distance(transform.position, objetivo.position) <= 0.1f)
            {
                CambiarObjetivo();
            }            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(enemyDamage);
        }
    }
    void CambiarObjetivo()
    {
        if (objetivo == waypointA)
        {
            objetivo = waypointB;
        }
        else
        {
            objetivo = waypointA;
        }
        CheckAnimation();
    }

    private void CheckAnimation()
    {
        anim.SetBool("MovingDown", waypointB == objetivo);
        anim.SetBool("MovingUp", waypointA == objetivo);
    }

    public void TakeDamage(int dmg)
    {
        enemyHealth -= dmg;

        if (enemyHealth < 1)
        {
            alive = false;
            Invoke("DestroyEnemyObject", 2f);
            anim.SetTrigger("Die");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void DestroyEnemyObject()
    {
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }
}
