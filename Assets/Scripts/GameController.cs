using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance = null;

    public Vector2 LastCheckpoint;

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
