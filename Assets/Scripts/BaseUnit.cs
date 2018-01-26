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

    public int WorldMod
    {
        get { return worldMod; }
        //set { worldMod = value; }
    }
}
