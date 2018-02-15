using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Graphic Splash;
	public Graphic Controls;
	public Graphic[] Content;

	private bool cont = false;


	private void Update()
	{
		if (cont && Input.GetKeyDown(KeyCode.Escape))
		{
			cont = false;
			Splash.CrossFadeAlpha(1.0f, 1.0f, true);
			foreach (Graphic img in Content){
				img.CrossFadeAlpha(1.0f, 1.0f, true);
			}
			
		}	
	}

	public void ShowControls()
	{
		cont = true;
		Splash.CrossFadeAlpha(0.0f, 1.0f, true);
		foreach (Graphic img in Content){
				img.CrossFadeAlpha(0.0f, 1.0f, true);
			}
	}

	public void Begin(){
		Splash.CrossFadeAlpha(0, 1.0f, true);
		foreach (Graphic img in Content){
				img.CrossFadeAlpha(0.0f, 1.0f, true);
			}
		Controls.CrossFadeAlpha(0,1.0f, true);
			
		GameController.LoadGame();
	}
}
