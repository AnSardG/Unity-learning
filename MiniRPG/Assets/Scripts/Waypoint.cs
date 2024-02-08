using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum TipoWaypoint { Fijo, Movil }
    public enum DireccionMovil { Horizontal, Vertical }

    public TipoWaypoint tipoWaypoint = TipoWaypoint.Fijo;
    public DireccionMovil dirMovil = DireccionMovil.Horizontal;
    public float recorridoSegundos = 2f, movementSpeed;

    private float time;
    private int direction = 1;

    void Start()
    {
        movementSpeed /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(tipoWaypoint == TipoWaypoint.Movil)
        {
            time += Time.deltaTime;
            if(time > recorridoSegundos)
            {
                ChangeDirection();
                time = 0;
            }
            MoveWaypoint();            
        }
    }

    private void ChangeDirection()
    {
        if (direction > 0)
        {
            direction = -1;
        } else
        {
            direction = 1;
        }
    }

    private void MoveWaypoint()
    {
        transform.position += CheckDirection(dirMovil) * Time.deltaTime * movementSpeed;
    }

    private Vector3 CheckDirection(DireccionMovil dir)
    {
        Vector3 newDirection;
        if(direction > 0)
        {
            if(dir == DireccionMovil.Horizontal)
            {
                newDirection = Vector3.right;
            } else
            {
                newDirection = Vector3.up;
            }            
        } else
        {
            if (dir == DireccionMovil.Horizontal)
            {
                newDirection = Vector3.left;
            }
            else
            {
                newDirection = Vector3.down;
            }
        }
        return newDirection;
    }
}
