using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpot : MonoBehaviour
{
    public GameObject[] objects;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            foreach(GameObject g in objects)
            {
                Destroy(g);
            }

            Destroy(this.gameObject);
        }
    }
}
