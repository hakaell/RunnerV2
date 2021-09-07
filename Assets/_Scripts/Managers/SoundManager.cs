using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : ASingleton<SoundManager>
{
    [SerializeField] AudioSource superRunSound;
    [SerializeField] AudioSource collectableSound;
    [SerializeField] AudioSource deathbellSound;
    [SerializeField] AudioSource fasterSound , faster2Sound;
    [SerializeField] AudioSource slowerSound;
    [SerializeField] AudioSource advideoSound;
    [SerializeField] AudioSource winSound;
    void Awake()
    {
        StartSingleton(this);
    }
    public void PlayWinSound()
    {
        if (!winSound.isPlaying)
        {
            winSound.Play();
        }
    }
    public void PlayBackgroundSound()
    {
        if (!advideoSound.isPlaying)
        {
            advideoSound.Play();
        }
    }
    public void PlaySuperRunSound()
    {
        if (!superRunSound.isPlaying)
        {
            superRunSound.Play();
        }
    }
    public void PlayCollectableSound()
    {
        collectableSound.Play();
    }
    public void PlayDeathbellSound()
    {
        if (!deathbellSound.isPlaying)
        {
            deathbellSound.Play();
        }
    }
    public void PlayFasterSounds()
    {
        int rando = Random.Range(0, 2);
        if (rando == 0)
        {
            fasterSound.Play();
        }
        else
        {
            faster2Sound.Play();
        }
    }
    public void PlaySlowerSound()
    {
        if (PlayerManager.Instance.currentState != PlayerManager.State.GameOver)
        {
            slowerSound.Play();
        }
    }
    public void StopBackgroundSound()
    {
        advideoSound.Stop();
    }
}
