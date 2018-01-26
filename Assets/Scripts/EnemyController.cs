using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseUnit {

    

    public GameObject EnemyPath;

    private float dir;

    // Use this for initialization
    void Start () {

        _SR = GetComponent<SpriteRenderer>();
        _RB = GetComponent<Rigidbody2D>();

		if (_SR.flipX)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveHoz(dir);
	}

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("AHHHHHHHH");
        if (other == EnemyPath.GetComponent<Collider>())
        {
            Debug.Log("SUUUUUUP");
            dir *= -1;
        }
    }
}
