using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip[] randomizedSounds;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (!source.isPlaying)
        {
            source.clip = randomizedSounds[Random.Range(0, randomizedSounds.Length - 1)];
            source.Play();
        }        
    }

    public void PlaySoundAlways()
    {
        source.clip = randomizedSounds[Random.Range(0, randomizedSounds.Length - 1)];
        source.Play();
    }
}
