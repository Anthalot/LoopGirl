using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public int startTime;
    public Text textTimer;
    float currentTime;
    void Start()
    {
        currentTime = startTime;
    }

    void FixedUpdate()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0f;
            playerController.Reset();
        }

        textTimer.text = "" + (int)currentTime;
    }

    public void RestartTimer()
    {
        currentTime = startTime;
    }
}
