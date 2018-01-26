using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : MonoBehaviour {

    //public PlayerController player;

    private Component[] components;

    private BoxCollider2D b_collider2d;
    private CapsuleCollider2D capL;
    private CapsuleCollider2D capR;

	// Use this for initialization
	void Start () {
        components = GetComponents(typeof(CapsuleCollider2D));
        b_collider2d = GetComponent<BoxCollider2D>();
        capL = (CapsuleCollider2D)components[0];
        capR = (CapsuleCollider2D)components[1];

        transform.position = new Vector3(Mathf.Round(transform.position.x) + 0.5f, Mathf.Round(transform.position.y) - 0.5f, 0);
        Debug.Log(this.tag + " snapped to " + transform.position);
	}

    // Update is called once per frame
    /*
	void FixedUpdate () {
        //if (player.Interacting && (capL.IsTouching(player.GetComponent<CapsuleCollider2D>()) || capR.IsTouching(player.GetComponent<CapsuleCollider2D>()))

        if()
	}
    */

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
    }
}
