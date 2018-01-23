using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void LoadGame()
    {
        SceneManager.LoadScene("Suenos_V04", LoadSceneMode.Single);
    }    
}
