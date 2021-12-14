using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public PlayerController playerController;
    public ParticleSystem walkParticles;
    public ParticleSystem jumpParticles;
    public ParticleSystem landParticles;
    public ParticleSystem returnParticles;

    public void HandleAllParticles()
    {
        WalkParticles();
        ReturnParticles();
    }

    void WalkParticles()
    {
        if(playerController.rb.velocity.x != 0 && playerController.Grounded() && !walkParticles.isPlaying) walkParticles.Play();
        else if(!playerController.Grounded() || playerController.rb.velocity.x == 0) walkParticles.Stop();
    }

    public void JumpParticles()
    {
        jumpParticles.Play();
    }

    public void LandParticles()
    {
        landParticles.Play();
    }

    void ReturnParticles()
    {
        if(playerController.returning && !returnParticles.isPlaying) returnParticles.Play();
        else returnParticles.Stop();
    }
}
