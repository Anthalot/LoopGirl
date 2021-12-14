using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
    public GameObject trail;
    public int startTime;
    public Text textTimer;
    float currentTime;
    bool trailSpawned;
    GameObject instantiatedTrail;
    void Start()
    {
        currentTime = startTime;
        trailSpawned = false;
    }

    void FixedUpdate()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            trailSpawned = false;
        }
        else
        {
            currentTime = 0f;
            playerController.Reset();
            if(!trailSpawned)
            {
                instantiatedTrail = Instantiate(trail, player.transform.position, Quaternion.identity);
                trailSpawned = true;
            }

            instantiatedTrail.transform.position = player.transform.position;
        }

        textTimer.text = "" + (int)currentTime;
    }

    public void RestartTimer()
    {
        currentTime = startTime;
    }
}
