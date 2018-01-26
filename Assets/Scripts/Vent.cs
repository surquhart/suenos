using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : Interactable {

    public Vent partner;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            collision.transform.position = partner.transform.position;
        }
    }
}
