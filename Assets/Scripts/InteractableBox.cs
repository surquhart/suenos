using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : MonoBehaviour {

    //public PlayerController player;

    private Rigidbody2D _RB;    
    private AudioController _AC;
    private AudioSource _AS;

	// Use this for initialization
	void Start () {
        _RB = GetComponent<Rigidbody2D>();
        _AC = GetComponent<AudioController>();
        _AS = GetComponent<AudioSource>();

        transform.position = new Vector3(Mathf.Round(transform.position.x) + 0.5f, Mathf.Round(transform.position.y) - 0.5f, 0);
        Debug.Log(this.tag + " snapped to " + transform.position);
	}

    private void Update()
    {
        if(_RB.velocity != Vector2.zero && !_AS.isPlaying)
        {
            _AC.PlaySound();
        }
        
    }
}
