using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : Interactable {

    public Vent partner;
    
    private AudioSource _AS;

    void Start()
    {
        _AS = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //does this fix teleporting boxes?
            if (collision.CompareTag("Player"))
            {
                _AS.Play();
                collision.transform.position = partner.transform.position; 
            }
            
        }
    }
}
