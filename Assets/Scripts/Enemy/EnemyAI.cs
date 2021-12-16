using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocity;
    int direction;

    void Start()
    {
        direction = 1;
    }

    void Update()
    {
        rb.velocity = new Vector2(direction * velocity, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        direction = -direction;
    }
}
