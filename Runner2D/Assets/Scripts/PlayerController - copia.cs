using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //VAR
    Vector3 moveTo;

    public Animator anim;

    public Text coinText;
    public Text healthText;

    int coins;

    public int health;

    public float limits = 3f, movement = 3f, speed = 40f;

    //METHODS
    void Start()
    {
        coinText.text = "Coins: 0";
        healthText.text = "HP: 3";
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health--;
            healthText.text = "HP: " + health;
            anim.SetBool("hit", true);
            if (health <= 0)
            {
                Time.timeScale = 0;
            }
            Invoke("StopHitAnimation", 1f);
        } else if (collision.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            if (health < 3)
            {                
                health++;
                healthText.text = "HP: " + health;
            }
        } else if (collision.CompareTag("Coin"))
        {
            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(collision.gameObject);
        }
    }

    void StopHitAnimation()
    {
        anim.SetBool("hit", false);
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < limits)
        {
            moveTo = new Vector3(0f, transform.position.y + movement, 0f);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -limits)
        {
            moveTo = new Vector3(0f, transform.position.y - movement, 0f);
        }
        transform.position = Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
    }
}
