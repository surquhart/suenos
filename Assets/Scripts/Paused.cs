using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paused : MonoBehaviour {

    public float SplitDist;

    public Image top;
    public Image bottom;

    public void OnEnable()
    {
        StartCoroutine(SlowTime());
        StartCoroutine(SplitScreen(1));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnPause();
        }
    }

    public void UnPause()
    {
        StartCoroutine(SplitScreen(-1));
    }

    /*
    public void OnDisable()
    {
        //StartCoroutine(SplitScreen(-1));
        //Debug.Log("Resume");
        top.rectTransform.anchoredPosition = new Vector2(0, 161.5f);
        bottom.rectTransform.anchoredPosition = new Vector2(0, -161.5f);
        Time.timeScale = 1;
    }
    */

    private IEnumerator SplitScreen(int dir)
    {
        float topTemp = top.rectTransform.anchoredPosition.y;
        float bottomTemp = bottom.rectTransform.anchoredPosition.y;
        for (float i = 0; i < SplitDist; i += 10)
        {
            Vector2 topMove = new Vector2(0, topTemp + i*dir);
            top.rectTransform.anchoredPosition = topMove;

            Vector2 bottomMove = new Vector2(0, bottomTemp - i*dir);
            bottom.rectTransform.anchoredPosition = bottomMove;

            yield return null;
        }
        if (dir < 0)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

    private IEnumerator SlowTime()
    {
        for (float i = 1; i > 0; i -= 0.05f)
        {
            Time.timeScale = i;
            Debug.Log(Time.timeScale);
            yield return null;
        }
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }
}
