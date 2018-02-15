using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour {

    private PlayerController playerScript;

    public Graphic _White;
    public Graphic _End;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EndCutscene();
        }
    }

    private void EndCutscene()
    {
        _White.CrossFadeAlpha(1, 1, true);
        StartCoroutine(Beat(1));
        _End.CrossFadeAlpha(1, 1, true);
        StartCoroutine(End());

        
    }

    private IEnumerator Beat(float secs)
    {
        yield return new WaitForSecondsRealtime(secs);
    }

    private IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(5);
        GameController.MainMenu();

    }
}
