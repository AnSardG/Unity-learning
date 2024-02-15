using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    private string direction;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Heart" && collision.tag != "Coin")
        {
            Destroy(gameObject);
        }
        
        
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void MoveTo()
    {
        transform.position += GetDirectionVector() * Time.deltaTime * speed;
    }

    private void SetDirection()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        if (Mathf.Approximately(eulerRotation.z, 90f))
        {
            direction = "left";
        }
        else if (Mathf.Approximately(eulerRotation.z, 270f))
        {
            direction = "right";
        }
        else if (Mathf.Approximately(eulerRotation.z, 180f))
        {
            direction = "down";
        }
        else
        {
            direction = "up";
        }
    }    

    private Vector3 GetDirectionVector()
    {
        switch (direction)
        {
            case "left":
                return Vector3.left;
            case "right":
                return Vector3.right;
            case "up":
                return Vector3.up;
            case "down":
                return Vector3.down;
            default:
                return Vector3.up; // Default to up direction if direction is not recognized
        }
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}
