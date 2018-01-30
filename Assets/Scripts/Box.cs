﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable {

    //public PlayerController player;

    private Rigidbody2D _RB;    
    private AudioController _AC;
    private AudioSource _AS;

	// Use this for initialization
	void Awake () {
        _RB = GetComponent<Rigidbody2D>();
        _AC = GetComponent<AudioController>();
        _AS = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if(_RB.velocity != Vector2.zero && !_AS.isPlaying)
        {
            _AC.PlaySound();
        }
        
    }
}