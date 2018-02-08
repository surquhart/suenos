using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Interactable : MonoBehaviour {

    protected bool active;

    /*
    void Start () {
        transform.position = new Vector3(Mathf.Round(transform.position.x) + 0.5f, Mathf.Round(transform.position.y) - 0.5f, 0);
        Debug.Log(this.tag + " snapped to " + transform.position);
    }
    */

    public bool Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }
}
