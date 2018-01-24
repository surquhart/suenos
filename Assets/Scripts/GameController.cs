using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
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
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadGameWrapper()
    {
        LoadGame();
    }
    
    public static void MainMenu()
    {
        SceneManager.LoadScene("Suenos_MainMenu", LoadSceneMode.Single);
    }

    public void MainMenuWrapper()
    {
        MainMenu();
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("Suenos_GameOver", LoadSceneMode.Additive);
        
    }

}
