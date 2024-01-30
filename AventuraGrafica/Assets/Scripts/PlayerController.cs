using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetHorizontalInput();
    }

    private void GetHorizontalInput()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x * speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
