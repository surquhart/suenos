using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable {

    public bool playerGot;

    private SpriteRenderer _SR;
    private Collider2D _C;

    private void Awake()
    {
        _C = GetComponent<Collider2D>();
        _SR = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _SR.enabled = false;
            _C.enabled = false;
            playerGot = true;
        }
    }
    
}
