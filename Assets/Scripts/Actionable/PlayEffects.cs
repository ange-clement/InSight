using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffects : Actionable
{

    public void setVolume(float volume)
    {
        AudioSource[] audios = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.volume = volume;
        }
    }

    public override void Activate()
    {
        AudioSource[] audios = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Play();
        }
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }

    public override void Deactivate()
    {
        AudioSource[] audios = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Stop();
        }
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }
    }
}
