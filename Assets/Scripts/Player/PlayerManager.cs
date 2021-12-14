using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController playerController;

    void Start()
    {
        
    }

    void Update()
    {
        playerController.HandleAllMovement();
    }
}
