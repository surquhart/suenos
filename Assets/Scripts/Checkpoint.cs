using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField]
    private PlayerController player;

    private bool _Triggered = false;


    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_Triggered)
        {
            _Triggered = true;
            GameController.instance.LastCheckpoint = transform.position;
        }
        
    }

}
