using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElvSwitch : MonoBehaviour
{
    
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
}
