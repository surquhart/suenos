using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject HUD;
    public GameObject PauseMenu;

    public Camera mainCam;
    public RenderTexture scrShot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameController.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (!PauseMenu.activeInHierarchy == true && mainCam.targetTexture != null)
        {
            HUD.SetActive(true);
            mainCam.targetTexture = null;
        }
    }

    public void Pause()
    {
        mainCam = FindObjectOfType<Camera>();
        mainCam.targetTexture = scrShot;
        HUD.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
