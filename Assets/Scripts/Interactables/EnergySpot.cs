using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpot : MonoBehaviour
{
    public GameObject[] objects;
    public SpriteRenderer spriteRenderer;
    public Color onColor;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            foreach(GameObject g in objects)
            {
                Destroy(g);
            }

            spriteRenderer.color = onColor;
        }
    }
}
