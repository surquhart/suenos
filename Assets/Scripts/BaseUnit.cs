using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class BaseUnit : MonoBehaviour {

    public float moveSpeed;
    public float animSpeed;

    protected int worldMod; //pos or neg integer value that changes physics based in each world.

    protected Rigidbody2D _RB;
    protected SpriteRenderer _SR;
    protected Animator _AN;

    // Use this for initialization
    void Awake () {
        _RB = GetComponent<Rigidbody2D>();
        _SR = GetComponent<SpriteRenderer>();
        _AN = GetComponent<Animator>();

        worldMod = 1;
    }

    protected void MoveHoz(float direction)
    {
        //Flips the orientation of the sprite
        if (direction < 0) _SR.flipX = true;
        else if (direction > 0) _SR.flipX = false;

        //apply velocity so it moves
        _RB.velocity = new Vector2(moveSpeed * direction, _RB.velocity.y);

        _AN.SetFloat("Velocity", Mathf.Abs(_RB.velocity.x) * (animSpeed / 10)); //Animation speed scales with velocity

    }

    //checks to see if the sprite is grounded
    protected bool IsGrounded(float offset)
    {
        Vector2 dir = new Vector2(0, -worldMod); //points the Ray from her feet

        //Raycast from both left and right side of sprite
        Vector3 origin = new Vector3(transform.position.x + offset, transform.position.y + 0.61f * -worldMod);

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, 0.15f);

        if (hit.collider != null)
        {
            //Debug.Log("true");
            return true;
        }

        //Debug.Log("false");
        return false;
    }

    //LAYERMASK OVERRIDE
    protected bool IsGrounded(float offset, int path)
    {
        Vector2 dir = new Vector2(0, -worldMod); //points the Ray from her feet

        //Raycast from both left and right side of sprite
        Vector3 origin = new Vector3(transform.position.x + offset, transform.position.y + 0.61f * -worldMod);

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, 0.15f, path);

        if (hit.collider != null)
        {
            //Debug.Log("true");
            return true;
        }

        //Debug.Log("false");
        return false;
    }

    public int WorldMod
    {
        get { return worldMod; }
        //set { worldMod = value; }
    }
}
