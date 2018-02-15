using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    
    public GameObject PauseMenu;

    public Graphic _White;
    public Graphic _End;

    public Camera mainCam;
    public RenderTexture scrShot;

    private void Awake()
    {
        _White.CrossFadeAlpha(0, 0, true);
        _End.CrossFadeAlpha(0, 0, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameController.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeInHierarchy)
        {
            Pause();
        }

        if (!PauseMenu.activeInHierarchy && mainCam.targetTexture != null)
        {
            mainCam.targetTexture = null;
        }
    }

    public void Pause()
    {
        mainCam = FindObjectOfType<Camera>();
        mainCam.targetTexture = scrShot;
        PauseMenu.SetActive(true);
    }
}
