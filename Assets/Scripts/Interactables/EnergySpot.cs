using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpot : MonoBehaviour
{
    public GameObject[] objects;
    public SpriteRenderer spriteRenderer;
    public Color onColor;
    Color startingColor;

    void Start()
    {
        startingColor = spriteRenderer.color;
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player" && collider2D.GetComponent<PlayerController>().returning)
        {
            foreach(GameObject g in objects)
            {
                g.SetActive(!g.activeSelf);
            }
            
            if(spriteRenderer.color == startingColor) spriteRenderer.color = onColor;
            else spriteRenderer.color = startingColor;
        }
    }
}
