using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleAndSound : Actionable
{
    public float timer;

    public float timerLeft;

    private void Update()
    {
        if (timerLeft > 0)
            timerLeft -= Time.deltaTime;
    }

    public bool isPlaying()
    {
        return timerLeft > 0;
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

        timerLeft = timer;
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
