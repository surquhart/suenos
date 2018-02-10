using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{
    public Sprite[] sprites;
    protected SpriteRenderer _SR;

    private void Awake()
    {
        _SR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (!active)
            {
                active = true;                
                _SR.sprite = sprites[1];
            }
        }
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (active)
        {
            active = false;
            _SR.sprite = sprites[0];
        }
    }
}
