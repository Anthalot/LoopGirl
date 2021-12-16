using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 0.2f;
    public float range = 1f;
    public GameObject elevator;
    public bool elevatorActive = false;
    public SpriteRenderer spriteRenderer;
    public Color onColor;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
           
                elevatorActive = true;
            

            spriteRenderer.color = onColor;
        }
    }
   
    void Update()
    {
        if (elevatorActive)
        {

            
                float y = Mathf.PingPong(Time.time * speed, range) * 6-3;
                elevator.transform.position = new Vector3(elevator.transform.position.x, y, elevator.transform.position.z);
            
        }
        
    }
   
}
