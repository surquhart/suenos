using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{


    /*
	private void OnTriggerEnter2D(Collider2D other)
	{
        Debug.Log("Trigger");
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            Debug.Log("Confirm");
            if (!active)
            {
                Debug.Log("Coroutine");
                StartCoroutine(Press(-1));
            }
            active = true;
        }
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (active)
        {
            StartCoroutine(Press(1));
        }
        active = false;
    }

    private IEnumerator Press(int dir){
        Vector3 pos = transform.position;
		for (int i = 0; i < 100; i++){
            pos = new Vector3(transform.position.x, transform.position.y + i * dir, 0);
            transform.position += pos;
            yield return null;
		}
	}
    */
}
