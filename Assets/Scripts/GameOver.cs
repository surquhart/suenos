using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text go_text;
    public Image go_background;

    public Text message;

    private bool canCont = false;

    private void Start()
    {
        StartCoroutine(FadeGAGraphic());
        StartCoroutine(FadeGAText());
        StartCoroutine(SlowTime());
        StartCoroutine(Restart());
    }

    private void Update()
    {
        if (Input.anyKeyDown && canCont)
        {
            Time.timeScale = 1;
            GameController.LoadGame();
        }
    }

    private IEnumerator FadeGAText()
    {
        for (float i = 0; i <= 1f; i += 0.01f)
        {
            Color c_text = go_text.material.color;
            c_text.a = i;
            go_text.material.color = c_text;

            yield return null;
        }
    }

    private IEnumerator FadeGAGraphic()
    {
        for (float i = 0; i <= 1600; i += 10)
        {
            go_background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, i);
            go_background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, i / 2);

            yield return null;
        }
    }

    private IEnumerator SlowTime()
    {
        for (float i = 1; i >= 0; i -= 0.01f)
        {
            Time.timeScale = i;

            yield return null;
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(3);
        message.text = "Press Any Key to Continue";
        canCont = true;
    }
}

