using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElvSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public bool elevatorActive = false;
    public SpriteRenderer spriteRenderer;
    public Color onColor;
    public float velocity;



    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {

            elevatorActive = true;


            spriteRenderer.color = onColor;
        }
    }
}
