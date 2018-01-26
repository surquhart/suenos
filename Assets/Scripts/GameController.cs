using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public GameObject HUD;
    public GameObject PauseMenu;

    public Camera mainCam;
    public RenderTexture scrShot;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (HUD.active == true && mainCam.targetTexture != null)
        {
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

    public void LoadGameWrapper()
    {
        LoadGame();
    }
    public static void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
        
    public void MainMenuWrapper()
    {
        MainMenu();
    }
    public static void MainMenu()
    {
        SceneManager.LoadScene("Suenos_MainMenu", LoadSceneMode.Single);
    }
    
    public static void GameOver()
    {
        SceneManager.LoadScene("Suenos_GameOver", LoadSceneMode.Additive);
    }

    public void ExitGameWrapper()
    {
        ExitGame();
    }
    public static void ExitGame()
    {
        Application.Quit();
    }
}
