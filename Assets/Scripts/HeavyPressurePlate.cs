using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPressurePlate : PressurePlate {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
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
        if (active && other.CompareTag("Box"))
        {
            active = false;
            _SR.sprite = sprites[0];
        }
    }
}