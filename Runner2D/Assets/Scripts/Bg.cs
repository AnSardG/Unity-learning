using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    float speed = 10f;
    BoxCollider2D bc;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -bc.size.x * transform.localScale.x)
        {
            transform.position += Vector3.right * bc.size.x * transform.localScale.x * 2;
        }
    }
}
