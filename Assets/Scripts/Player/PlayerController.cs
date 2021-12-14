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
    [Header("Mirror")]
    public float reflectiveForce;
    
    Vector2 resetVelocity = Vector3.zero;
    float playerDirection;

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
        if(rb.velocity.x > 0) playerDirection = 1;
        else if (rb.velocity.x < 0) playerDirection = -1;
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

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 7 && returning)
        {
            rb.AddForce(Vector2.right * playerDirection * reflectiveForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.layer == 6)
        {
            Debug.Log(collision2D.GetContact(0).normal);
            if(collision2D.GetContact(0).normal.x == 0 && collision2D.GetContact(0).normal.y == 1)
            {
                particlesManager.LandParticles();
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.layer == 6)
        {
            if(collision2D.GetContact(0).normal.x == 0)
            {
                grounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.layer == 6)
        {
            grounded = false;
            particlesManager.JumpParticles();
        } 
    }
}
