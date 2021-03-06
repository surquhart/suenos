﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
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
            Transform ground;
            if (CanSwitch(out ground))
            {
                Debug.Log("Try Switch");
                SwitchWorld(ground);
            }
        }

        //calls the jump method
        if (Input.GetKeyDown("space") && IsGrounded()){
            Jump();
        }
	    
	    //Jump Ray
	    
	    Vector3 pos1 = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.7f*-worldMod);
	    Vector3 pos2 = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.7f*-worldMod);
	    
	    Debug.DrawRay(pos1, Vector3.down*0.1f*worldMod, Color.green);
	    Debug.DrawRay(pos2, Vector3.down*0.1f*worldMod, Color.green);
	    
		//Switch Ray
	    //Debug.DrawRay(transform.position, Vector3.down*0.8f*worldMod, Color.blue);
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
    private bool IsGrounded()
    {
        Vector2 dir = new Vector2(0, -worldMod); //points the Ray from her feet

        //Raycast from both left and right side of sprite
        Vector3 oriLeft = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.7f*-worldMod);
        Vector3 oriRight = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.7f*-worldMod);

        RaycastHit2D hitLeft = Physics2D.Raycast(oriLeft, dir, 0.1f);
        RaycastHit2D hitRight = Physics2D.Raycast(oriRight, dir, 0.1f);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            //Debug.Log("true");
            return true;
        }
        
        //Debug.Log("false");
        return false;
    }

    private bool CanSwitch(out Transform ground)
    {
        Vector2 dir = new Vector2(0, -worldMod);
        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 0.8f*-worldMod);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 0.8f, groundLayer);
        RaycastHit2D hit = Physics2D.Raycast(origin, dir, 0.8f);
        Debug.Log(hit.distance);

        /*
        ground = hit.transform;
        Debug.Log(ground.position.x);
        Debug.Log(ground.position.y);
        Debug.Log(ground.position.z);
        */
        
        if (hit.collider != null)
        {
            ground = hit.transform;
            return true;
        }
        
        ground = null;
        return false;
        
        /*
        Debug.Log("Hit Left Distance: " + hitLeft.distance);
        Debug.Log("Hit Right Distance: " + hitRight.distance);
        
        if (hitLeft.distance <= 1.0f)
        {
            ground = hitLeft.transform;
            Debug.Log("Left Hit");
            return true;
        } 
        else if (hitRight.distance <= 1.0f)
        {
            ground = hitRight.transform;
            Debug.Log("Right Hit");
            return true;
        }
        else
        {
            ground = null;
            Debug.Log("No Hit");
            return false;
        }
        */
    }


    //Switches the girl between worlds, then flips gravity so she doesn't fall off into space.
    private void SwitchWorld(Transform ground)
    {
        if (Time.time >= nextSwitch)
        {
            worldMod *= -1;

            _RB.transform.localScale = new Vector3(_RB.transform.localScale.x, -(_RB.transform.localScale.y), _RB.transform.localScale.z);

            _RB.transform.position = new Vector3(_RB.transform.position.x, -worldMod*(ground.position.y + worldMod), _RB.transform.position.z); //Fix this.

            _RB.velocity = new Vector2(_RB.velocity.x, -(_RB.velocity.y));

            _RB.gravityScale *= -1; 

            nextSwitch = Time.time + switchCoolTime; //cooldown before the switch ability can be used again.
        }               
    }
}
