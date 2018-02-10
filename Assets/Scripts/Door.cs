using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable{

    public Key[] keys;

    private Collider2D _CC;

    private void Awake()
    {
        _CC = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update () {
		if (keys[0].playerGot && keys[1].playerGot && keys[2].playerGot)
        {
            _CC.enabled = false;
        }
	}
}
