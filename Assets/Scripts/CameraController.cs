using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float zoom;
	
    private Vector3 offset;
    //private float pedestal = 0.0f;

    public PlayerController player;
    

	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		Vector3 pos = new Vector3(offset.x, offset.y*player.WorldMod, offset.z*zoom);
        transform.position = player.transform.position + pos;
	}
}
