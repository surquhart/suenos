using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDetector : MonoBehaviour {

    private bool isColliding;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }

    public bool IsColliding
    {
        get
        {
            return isColliding;
        }
    }
}
