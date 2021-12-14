using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public ParticlesManager particlesManager;
    [Header("Movement")]
    public Rigidbody2D rb;
    public int velocity;
    public float jumpForce;
    public float direction;
    public bool grounded;
    public Collider2D playerCollider;
    [Header("Reset")]
    public float resetSpeed;
    public Transform startPoint;
    public bool returning;
    
    Vector2 resetVelocity = Vector3.zero;

    void Start()
    {
        returning = false;
    }

    public void HandleAllMovement()
    {
        if(returning) return;
        Move();
        Jump();
        Direction();
    }

    public void Reset()
    {
        if(!returning)
        {
            rb.velocity = Vector2.zero;
            playerCollider.isTrigger = true;
            rb.gravityScale = 0f;
            returning = true;
        }

        if(transform.position == startPoint.position)
        {
            returning = false;
            playerCollider.isTrigger = false;
            rb.gravityScale = 1f;
            gameManager.RestartTimer();
        }

        if(returning) transform.position = Vector2.SmoothDamp(transform.position, startPoint.position, ref resetVelocity, resetSpeed * Time.deltaTime);
    }

    void Direction()
    {
        direction = Input.GetAxisRaw("Horizontal");
    }

    void Move()
    {
        rb.velocity = new Vector2(direction * velocity, rb.velocity.y);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Grounded()) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0 && !Grounded()) rb.velocity = new Vector2(rb.velocity.x, 0f);
    }

    public bool Grounded()
    {
        return grounded;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.layer == 6)
        {
            if(collision2D.GetContact(0).normal.x == 0)
            {
                grounded = true;
                //particlesManager.LandParticles();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.layer == 6)
        {
            grounded = false;
            //particlesManager.JumpParticles();
        } 
    }
}
