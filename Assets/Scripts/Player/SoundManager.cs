using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource walkSound;
    public AudioSource landSound;
    public AudioSource deathSound;
    public AudioSource resetSound;
    public AudioSource energySound;

    public void PlayJumpSound()
    {
        if(!jumpSound.isPlaying) jumpSound.Play();
    }

    public void PlayWalkSound()
    {
        if(!walkSound.isPlaying) walkSound.Play();
    }

    public void PlayLandSound()
    {
        if(!landSound.isPlaying) landSound.Play();
    }

    public void PlayDeathSound()
    {
        if(!deathSound.isPlaying) deathSound.Play();
    }

    public void PlayResetSound()
    {
        if(!resetSound.isPlaying) resetSound.Play();
    }

    public void PlayEnergySound()
    {
        if(!energySound.isPlaying) energySound.Play();
    }
}
