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
        Vector3 origin = new Vector3(transform.position.x + 2.0f*dir, transform.position.y);
        Vector2 direction = new Vector2(dir, 0);
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 8.0f);
        Debug.DrawRay(origin, new Vector3(dir, 0, 0), Color.blue);

        if (hit.collider != null && !hit.collider.CompareTag("Player"))
        {
            MoveHoz(dir);
            return;
        }

        if (!IsGrounded(-0.3f, 10))
        {
            dir = 1;

        }

        if (!IsGrounded(-0.3f, 10))
        {
            dir = -1;
        }

        MoveHoz(dir);
	}
}
