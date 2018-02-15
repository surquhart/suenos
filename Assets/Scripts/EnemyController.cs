using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseUnit
{
    public GameObject L_EnemyTurner;
    public GameObject R_EnemyTurner;

    public bool wait = false;

    private bool chase;
    private float dir;

    // Use this for initialization
    void Start ()
    {
        _SR = GetComponent<SpriteRenderer>();
        _RB = GetComponent<Rigidbody2D>();
        dir = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y);
        Vector2 direction = new Vector2(dir, 0);
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 3.0f, LayerMask.GetMask("Player"));
        Debug.DrawRay(origin, new Vector3(dir * 3, 0, 0), Color.blue);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            chase = true;
        }
        else
        {
            chase = false;
        }
        
        if(chase == false)
        {
            if (transform.position.x > L_EnemyTurner.transform.position.x && transform.position.x > R_EnemyTurner.transform.position.x)
            {
                dir = -1;
            }
            else if (transform.position.x < R_EnemyTurner.transform.position.x && transform.position.x < L_EnemyTurner.transform.position.x)
            {
                dir = 1;
            }
        }

        if (wait && !chase)
        {
            return;
        }
        MoveHoz(dir);
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!chase && other.CompareTag("EnemyTurner"))
        {
            dir *= -1;
        }
    }

}