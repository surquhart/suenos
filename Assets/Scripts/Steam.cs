using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : Interactable {

    public Interactable trigger;
    public PlayerController player;

    private Animator _AN;
    private AudioSource _AS;

    private void Awake()
    {
        _AN = GetComponent<Animator>();
        _AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		if (!trigger.Active)
        {
            if(!_AS.isPlaying)
            {
                _AS.Play();
            }
            active = true;
            _AN.SetBool("Active", true);
            
        }
        else
        {
            if(_AS.isPlaying)
            {
                _AS.Stop();
            }
            active = false;
            _AN.SetBool("Active", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && active)
        {
            player.Die();
        }
    }
}