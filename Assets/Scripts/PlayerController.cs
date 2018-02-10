using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : BaseUnit
{

    public float jumpVert; //the vertical velocity applied to Alice when she jumps
    public float jumpHoz; //unused
    public float switchCoolTime; //Cooldown before switch can be used again
    //public float maxFall; //the maximum safe height Alice can fall. Checked against her Y velocity

    public SwitchDetector _SD;
    public LayerMask ground;

    [HideInInspector]
    public float nextSwitch = 0.0f; //countdown for Alice to be able to switch again

    //private bool interacting; //boolean that returns if the player is pressing X
    private bool isAlive; //is Alice still alive? The game stops if this is false
    private bool falling; //is the player in the air? Prevents the FallingDamage coroutine from running multiple times simultaneously
    private bool crawling;

    [SerializeField]
    private bool step;

    private Vector2 crawlColliderOffset = new Vector2(0, -0.5f);
    private Vector2 crawlColliderSize = new Vector2(1.45f, 0.5f);

    private void Start()
    {
        isAlive = true;
        falling = false;

        if(GameController.instance.LastCheckpoint != Vector2.zero)
        {
            transform.position = GameController.instance.LastCheckpoint;
        }

    }


    // Update is called once per frame
    void Update ()
    {
        if (!isAlive)
        {
            //exit without doing anything if Alice is dead
            return;
        }

        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {

            //Transform ground;
            if (CanSwitch())
            {
                //Debug.Log("Try Switch");
                SwitchWorld();
            }
        }

        
        // AUDIO GOES HERE
        if (step)
        {
            step = false;
            _AC.PlaySound();
        }
        

        
        //calls the jump method
        if (Input.GetKeyDown("space") && !crawling && IsGrounded())
        {            
            Jump();
        }

        
        if (IsGrounded())
        {
            _AN.SetBool("Jumping", false);
            
        }
        else
        {
            _AN.SetBool("Jumping", true);
            /*
            if (!falling)
            {
                StartCoroutine(FallingDamage());
            }
            */
        }

        

        if (Input.GetKeyDown(KeyCode.LeftControl) && IsGrounded())
        {
            if (!crawling)
            {
                crawling = true;
                _AN.SetBool("Crawling", true);
                moveSpeed /= 2;
                _CC.offset = crawlColliderOffset;
                _CC.size = crawlColliderSize;
                _CC.direction = CapsuleDirection2D.Horizontal;

            }
            else
            {
                crawling = false;
                _AN.SetBool("Crawling", false);
                moveSpeed *= 2;
                _CC.offset = Vector2.zero;
                _CC.size = new Vector2(0.5f, 1.45f); //original size of player collider
                _CC.direction = CapsuleDirection2D.Vertical;
            }
        }
        
	    
	    //Jump Ray
	    
	    Vector3 pos1 = new Vector3(transform.position.x - rayCasterOffsetX, transform.position.y + rayCasterOffsetY*-worldMod);
	    Vector3 pos2 = new Vector3(transform.position.x + rayCasterOffsetX, transform.position.y + rayCasterOffsetY*-worldMod);
	    
	    Debug.DrawRay(pos1, Vector3.down*0.15f*worldMod, Color.green);
	    Debug.DrawRay(pos2, Vector3.down*0.15f*worldMod, Color.green);

        //Switch Ray
        Vector3 swiPos = new Vector3(transform.position.x, transform.position.y + 0.975f * -worldMod);
	    Debug.DrawRay(swiPos, Vector3.down*10.0f*worldMod, Color.blue);
	    
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
        
    }

    private bool CanSwitch()
    {
        Vector2 dir = new Vector2(0, -worldMod);

        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 0.725f*-worldMod);

        /*
        Vector3 oriLeft = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.975f * -worldMod);
        Vector3 oriRight = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.975f * -worldMod);
        */

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, 10.0f, ground);
        //Vector3 newPos = new Vector3(hit.point.x, hit.point.y + 1.5f * worldMod);
        _SD.transform.position = hit.point;
        _SD.transform.localScale = new Vector3(1, worldMod, 1);

        //Ensures that the player cannot switch and end up in some geo in the other world
        /*
        RaycastHit2D hitLeft = Physics2D.Raycast(oriLeft, dir, 5.0f);
        RaycastHit2D hitRight = Physics2D.Raycast(oriRight, dir, 5.0f);
        */

        if (IsGrounded() && !_SD.IsColliding)
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

            /* Color switching, from before sprite was coloured
            if (worldMod == 1)
            {
                _SR.color = Color.black;
            }
            else
            {
                _SR.color = Color.white;
            }
            */
            

            _RB.gravityScale *= -1; 

            nextSwitch = Time.time + switchCoolTime; //cooldown before the switch ability can be used again.
        }               
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Die();
        }
    }

    /*
    //Kills Alice if she falls from too great a height.
    private IEnumerator FallingDamage()
    {
        falling = true;
        while (!IsGrounded())
        {
            yield return null;
        }
        //Compare Alice's fall speed against the maximum safe falling distance
        if (Mathf.Abs(_RB.velocity.y) > maxFall && !(Input.GetKey("left shift") || Input.GetKey("right shift")))
        {
            Die();
        }
        falling = false;
    }
    */

    public void Die()
    {
        isAlive = false;
        GameController.GameOver();
    }

    /*
    public bool Interacting
    {
        get { return interacting; }
    }
    */

    public bool IsAlive
    {
        get { return isAlive; }
    }
}
