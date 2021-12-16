using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController playerController;
    public ParticlesManager particlesManager;

    void Update()
    {
        playerController.HandleAllMovement();
        particlesManager.HandleAllParticles();
    }
    
}
