using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;

    public GameObject EnemyPath;

    private float dir;

    private Rigidbody2D _RB;
    private SpriteRenderer _SR;
    private Animator _AN;

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

    private void MoveHoz(float direction)
    {
        //Flips the orientation of the sprite
        if (direction < 0) _SR.flipX = true;
        else if (direction > 0) _SR.flipX = false;

        //Debug.Log("Moving");
        //apply velocity so it moves
        _RB.velocity = new Vector2(moveSpeed * direction, _RB.velocity.y);


        //_AN.SetFloat("Velocity", Mathf.Abs(_RB.velocity.x) * (animSpeed / 10)); //Animation speed scales with velocity

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
