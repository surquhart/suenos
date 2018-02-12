using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDetector : MonoBehaviour {

    private bool isColliding;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding");
        isColliding = true;
        Debug.Log(isColliding);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Not Colliding");
        isColliding = false;
        Debug.Log(isColliding);
    }

    public bool IsColliding
    { 
        get
        {
            return isColliding;
        }
    }
}
