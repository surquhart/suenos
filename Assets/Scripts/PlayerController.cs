using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;



public class PlayerController : BaseUnit {

    
    public float jumpVert;
    public float jumpHoz;
    public float switchCoolTime;
    public float nextSwitch = 0.0f;
    
    private bool interacting; //boolean that returns if the player is pressing X
    
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            
            //Transform ground;
            if (CanSwitch())
            {
                //Debug.Log("Try Switch");
                SwitchWorld();
            }
        }

        
        if (Input.GetKey("x"))
        {
            //USE PLAYER INPUT
        }

        //calls the jump method
        if (Input.GetKeyDown("space") && IsGrounded()){
            Jump();
        }
	    
	    //Jump Ray
	    
	    Vector3 pos1 = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.61f*-worldMod);
	    Vector3 pos2 = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.61f*-worldMod);
	    
	    Debug.DrawRay(pos1, Vector3.down*0.15f*worldMod, Color.green);
	    Debug.DrawRay(pos2, Vector3.down*0.15f*worldMod, Color.green);

        //Switch Ray
        Vector3 swiPos = new Vector3(transform.position.x, transform.position.y + 0.975f * -worldMod);
	    Debug.DrawRay(swiPos, Vector3.down*1.3f*worldMod, Color.blue);
	    
	    Vector3 swiGround = new Vector3(transform.position.x, transform.position.y + 0.725f*-worldMod);
	    Debug.DrawRay(swiGround, Vector3.down*0.2f*worldMod, Color.red);
	}

    private void FixedUpdate()
    {        
        
         float h = Input.GetAxis("Horizontal");
         MoveHoz(h);
                             
    }

    // causes the sprite to jump
    
    private void Jump()
    {
        _RB.velocity += new Vector2(0, jumpVert * worldMod);
        //_RB.velocity += new Vector2(0, jumpVert * worldMod);
        
    }

    //checks to see if the sprite is grounded
    private bool IsGrounded()
    {
        Vector2 dir = new Vector2(0, -worldMod); //points the Ray from her feet

        //Raycast from both left and right side of sprite
        Vector3 oriLeft = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.61f*-worldMod);
        Vector3 oriRight = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.61f*-worldMod);

        RaycastHit2D hitLeft = Physics2D.Raycast(oriLeft, dir, 0.15f);
        RaycastHit2D hitRight = Physics2D.Raycast(oriRight, dir, 0.15f);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            //Debug.Log("true");
            return true;
        }
        
        //Debug.Log("false");
        return false;
    }

    private bool CanSwitch()
    {
        Vector2 dir = new Vector2(0, -worldMod);

        Vector3 originCent = new Vector3(transform.position.x, transform.position.y + 0.725f*-worldMod);

        Vector3 oriLeft = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.975f * -worldMod);
        Vector3 oriRight = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.975f * -worldMod);
        
        //Older raycast. Gets grounf type. Keep in case of teleport switching
        //RaycastHit2D groundCaster = Physics2D.Raycast(origin, dir, 0.1f);

        RaycastHit2D hitCent = Physics2D.Raycast(originCent, dir, 0.2f);

        //Ensures that the player cannot switch and end up in some geo in the other world
        RaycastHit2D hitLeft = Physics2D.Raycast(oriLeft, dir, 1.3f);
        RaycastHit2D hitRight = Physics2D.Raycast(oriRight, dir, 1.3f);
        
        if (hitLeft.collider == null && hitRight.collider == null && hitCent.collider != null)
        {
            
            //ground = groundCaster.transform;
            return true;
        }

        return false;
    }


    //Switches the girl between worlds, then flips gravity so she doesn't fall off into space.
    private void SwitchWorld()
    {
        if (Time.time >= nextSwitch)
        {
            worldMod *= -1;

            _RB.transform.localScale = new Vector3(_RB.transform.localScale.x, -(_RB.transform.localScale.y), _RB.transform.localScale.z);

            _RB.transform.position = new Vector3(_RB.transform.position.x, transform.position.y + worldMod*1.25f, _RB.transform.position.z); //Fix this.

            //_RB.velocity = new Vector2(_RB.velocity.x, -(_RB.velocity.y));

            if (worldMod == 1)
            {
                _SR.color = Color.black;
            }
            else
            {
                _SR.color = Color.white;
            }
            

            _RB.gravityScale *= -1; 

            nextSwitch = Time.time + switchCoolTime; //cooldown before the switch ability can be used again.
        }               
    }
    
    public bool Interacting
    {
        get { return interacting; }
    }
}
