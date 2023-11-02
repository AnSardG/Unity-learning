using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VAR
    float speed = 10f;
    public Animator anim;

    //METHODS
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
