using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : Interactable {

    public Interactable trigger;
    public PlayerController player;

    private Animator _AN;

    private void Awake()
    {
        _AN = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if (!trigger.Active)
        {
            active = true;
            _AN.SetBool("Active", true);
        }
        else
        {
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
