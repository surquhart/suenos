using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePressurePlate : PressurePlate {

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}
