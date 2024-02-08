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

    // Private VARS
    private Transform objetivo;

    
    void Start()
    {
        objetivo = waypointB;
        velocidad /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(tipoEnemigo == TipoEnemigo.Movil)
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
    }

    public void TakeDamage(int dmg)
    {
        enemyHealth -= dmg;

        if (enemyHealth < 1)
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}
