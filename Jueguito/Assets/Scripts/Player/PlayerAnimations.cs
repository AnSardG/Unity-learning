using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;
    private BoxCollider2D coll;
    private SpriteRenderer sr;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Slider energySlider;    
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {        
        if (Input.GetKey(KeyCode.A))
        {
            if (!sr.flipX)
            {
                sr.flipX = true;
            }
        } else if (Input.GetKey(KeyCode.D))
        {
            if (sr.flipX)
            {
                sr.flipX = false;
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(coll.bounds.center, Vector2.up, 2f, groundMask);
        bool isThroughGround = hit.collider != null && hit.collider.tag == "Through";

        if (IsGrounded() && !isThroughGround)
        {            
            playerAnimator.SetBool("jumping", false);
            playerAnimator.SetBool("flying", false);
            if (Input.GetKey(KeyCode.A))
            {                                            
                playerAnimator.SetBool("running", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerAnimator.SetBool("running", true);                               
            }
            else
            {
                playerAnimator.SetBool("running", false);                
            }
        }
        else
        {
            playerAnimator.SetBool("running", false);            
            if (Input.GetKey(KeyCode.E) && energySlider.value >= 10f)
            {
                playerAnimator.SetBool("flying", true);
                playerAnimator.SetBool("jumping", false);
            }
            else
            {
                playerAnimator.SetBool("flying", false);
                playerAnimator.SetBool("jumping", true);
            }
        }            
    }

    public bool IsGrounded()
    {        
        Vector2 size = coll.bounds.size;
        size.x -= .1f;
        size.y -= .1f;
        return Physics2D.BoxCast(coll.bounds.center, size, 0f, Vector2.down, .1f, groundMask);
    }    
}
