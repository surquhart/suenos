using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable{

    public Key[] keys;
    public Sprite OpenDoor;

    private Collider2D _CC;
    private SpriteRenderer _SR;

    private void Awake()
    {
        _CC = GetComponent<Collider2D>();
        _SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Key key in keys)
            {
                if (!key.playerGot)
                    return;
            }
            _SR.sprite = OpenDoor;
            _CC.enabled = false;
    }       
}
