using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip[] randomizedSounds;

    private AudioSource source = new AudioSource();

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound() {
        source.clip = randomizedSounds[Random.Range(0, randomizedSounds.Length - 1)];
        source.Play();
    }
}
