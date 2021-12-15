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
        rb.velocity = Vector2.right * direction * velocity;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        direction = -direction;
    }
}
