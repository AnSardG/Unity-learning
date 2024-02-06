using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;

    private bool rotated = false;
    private string direction = "up";

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo();
    }

    private void MoveTo()
    {
        switch (direction)
        {
            case "left":
                if (!rotated)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 90f);
                    rotated = true;
                } else
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                }
                break;
            case "right":
                if (!rotated)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -90f);
                    rotated = true;
                }
                else
                {
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
                break;
            case "up":
                if (!rotated)
                {                    
                    rotated = true;
                }
                else
                {
                    transform.position += Vector3.up * Time.deltaTime * speed;
                }
                break;
            case "down":
                if (!rotated)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 180f);
                    rotated = true;
                }
                else
                {
                    transform.position += Vector3.down * Time.deltaTime * speed;
                }
                break;
        }
    }

    public void SetDirection(string direction)
    {
        this.direction = direction;
    }
}
