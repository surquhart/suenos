using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
//[RequireComponent(typeof(Animator))]

public class BaseUnit : MonoBehaviour {

    public float moveSpeed;
    public float animSpeed;
    public float rayCasterOffsetX;
    public float rayCasterOffsetY;

    protected int worldMod; //pos or neg integer value that changes physics based in each world.

    protected Rigidbody2D _RB;
    protected SpriteRenderer _SR;
    protected Animator _AN;
    protected CapsuleCollider2D _CC;

    // Use this for initialization
    void Awake () {
        _RB = GetComponent<Rigidbody2D>();
        _SR = GetComponent<SpriteRenderer>();
        _AN = GetComponent<Animator>();
        _CC = GetComponent<CapsuleCollider2D>();

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

    //LAYERMASK OVERRIDE
    protected bool IsGrounded()
    {
        Vector2 dir = new Vector2(0, -worldMod); //points the Ray from her feet

        //Raycast from both left and right side of sprite
        Vector3 originRight = new Vector3(transform.position.x + rayCasterOffsetX, transform.position.y + rayCasterOffsetY * -worldMod);
        Vector3 originLeft = new Vector3(transform.position.x - rayCasterOffsetX, transform.position.y + rayCasterOffsetY * -worldMod);

        RaycastHit2D hitRight = Physics2D.Raycast(originRight, dir, 0.15f);
        RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, dir, 0.15f);

        if (hitLeft.collider != null && hitRight.collider != null)
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
