using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public ParticlesManager particlesManager;
    public SoundManager soundManager;
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
    public GameObject trail;
    bool trailSpawned;
    GameObject instantiatedTrail;
    [Header("Mirror")]
    public float reflectiveForce;
    

    void Start()
    {
        returning = false;
        trailSpawned = false;
    }

    public void HandleAllMovement()
    {
        if(returning)
        {
            Reset();
            return;
        }
        Move();
        Jump();
        Direction();
    }

    public void Reset()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, resetSpeed * Time.deltaTime);

        if(!trailSpawned)
        {
            instantiatedTrail = Instantiate(trail, transform.position, Quaternion.identity);
            trailSpawned = true;
        }

        if(instantiatedTrail != null) instantiatedTrail.transform.position = transform.position;
        
    }

    void Direction()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) soundManager.PlayWalkSound();
    }

    void Move()
    {
        rb.velocity = new Vector2(direction * velocity, rb.velocity.y);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            soundManager.PlayJumpSound();
        }
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0 && !Grounded()) rb.velocity = new Vector2(rb.velocity.x, 0f);
    }

    public bool Grounded()
    {
        return grounded;
    }

    public void Return()
    {
        if(!returning)
        {
            soundManager.PlayResetSound();
            rb.velocity = Vector2.zero;
            playerCollider.isTrigger = true;
            rb.gravityScale = 0f;
            returning = true;
            trailSpawned = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.layer == 7 && returning)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(collider2D.transform.right * reflectiveForce, ForceMode2D.Impulse);
            StartCoroutine("MirrorBounce");
        }
        if(collider2D.tag == "StartPos" && returning)
        {
            returning = false;
            playerCollider.isTrigger = false;
            rb.gravityScale = 1f;
            gameManager.RestartTimer();
        }
        if(collider2D.tag == "Enemy" && returning)
        {
            soundManager.PlayDeathSound();
            Destroy(collider2D.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.layer == 6)
        {
            if(collision2D.GetContact(0).normal.x == 0 && collision2D.GetContact(0).normal.y == 1)
            {
                soundManager.PlayLandSound();
                particlesManager.LandParticles();
            }
        }
        if(collision2D.gameObject.tag == "Enemy") Return();
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

    IEnumerator MirrorBounce()
    {
        rb.gravityScale = 1f;
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        StopCoroutine("MirrorBounce");
    }
}
