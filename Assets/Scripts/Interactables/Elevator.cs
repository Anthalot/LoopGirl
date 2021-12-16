using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    int direction;
    public Rigidbody2D rbElevator;
    public float velocity;
    public ElvSwitch ElvSwitch;
    void Start()
    {
        velocity = 2;
        direction = 1;
        rbElevator = this.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Waypoint")
        {
            direction = -direction;
        }
        
    }
    void Update()
    {
        if (ElvSwitch.elevatorActive)
        {

            rbElevator.velocity = Vector2.up * direction * velocity;

        }

    }
}
