using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PRIVATE VARS
    float vertical, horizontal;

    // PUBLIC VARS
    public float speed = 10f;
    public int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        GetVerticalInput();
    }

    private void GetVerticalInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    
        Vector3 newPosition = new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, transform.position.z);
        transform.position += newPosition;

    }
}
