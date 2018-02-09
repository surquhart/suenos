using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    
    public Text coolDown;


    public PlayerController player;

	// Use this for initialization
	void Start () {

        coolDown.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Time.time >= player.nextSwitch)
        {
            coolDown.text = "Switch Ready";
        } else
        {
            coolDown.text = "";
        }        
	}
}
