using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float switchCoolTime;
    public float nextSwitch = 0.0f;

    [HideInInspector]
    public int worldMod; //pos or neg integer value that changes physics based in each world.

    public LayerMask groundLayer;

    private Rigidbody2D _RB;
    private SpriteRenderer _SR;
    private Animator _AN;
         
	// Fetch all components
	void Start () {
        _RB = GetComponent<Rigidbody2D>();
        _SR = GetComponent<SpriteRenderer>();
        _AN = GetComponent<Animator>();

        worldMod = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
        {
            SwitchWorld();
        }

        //calls the jump method
        if (Input.GetKeyDown("space") && IsGrounded(0)){
            Jump();
        }
		
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        MoveHoz(h);              
    }

    // causes the sprite to jump
    private void Jump()
    {
        _RB.velocity = new Vector2(_RB.velocity.x, jumpSpeed*worldMod);         
    }

    private void MoveHoz(float direction)
    {
        //Flips the orientation of the sprite
        if (direction < 0) _SR.flipX = true;
        else if (direction > 0) _SR.flipX = false;        

        //apply velocity so it moves
        _RB.velocity = new Vector2(moveSpeed * direction, _RB.velocity.y);

        
        _AN.SetFloat("Velocity", Mathf.Abs(_RB.velocity.x)*0.5f); //Animation speed scales with velocity
               
    }

    //checks to see if the sprite is grounded
    bool IsGrounded(int typ)
    {
        Vector2 dir = new Vector2(0, -worldMod);

        //Raycast from both left and right side of sprite
        Vector3 oriLeft = new Vector3(transform.position.x - 0.2f, transform.position.y);
        Vector3 oriRight = new Vector3(transform.position.x + 0.2f, transform.position.y);

        RaycastHit2D hitLeft = Physics2D.Raycast(oriLeft, dir, 5.0f, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(oriRight, dir, 5.0f, groundLayer);

        if (typ == 0)
        {
            if (_RB.IsTouching(hitLeft.collider) || _RB.IsTouching(hitRight.collider)) //IMPORTANT: Needs case for null reference
            {
                //Debug.Log("True");
                return true;
            }
            //Debug.Log("False");
            return false;
        }
        else if (typ == 1)
        {

        }
        
        //Notifies if function is given incorrect variable
        Debug.Log("Value of variable \"typ\" is invalid.");
        return false;
    }


    //Switches the girl between worlds, then flips gravity so she doesn't fall off into space.
    private void SwitchWorld()
    {
        if (Time.time >= nextSwitch)
        {
            worldMod *= -1;

            _RB.transform.localScale = new Vector3(_RB.transform.localScale.x, -(_RB.transform.localScale.y), _RB.transform.localScale.z);

            _RB.transform.position = new Vector3(_RB.transform.position.x, -(_RB.transform.position.y), _RB.transform.position.z);

            _RB.velocity = new Vector2(_RB.velocity.x, -(_RB.velocity.y));

            _RB.gravityScale *= -1; 

            nextSwitch = Time.time + switchCoolTime; //cooldown before the switch ability can be used again.
        }               
    }
}
