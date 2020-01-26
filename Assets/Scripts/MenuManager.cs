using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update () {

		
		
	}

	
	public void startGame()
	{
//		Debug.Log("WTF");
		SceneManager.LoadScene("game");
	}

	public void showLoseMenu()
	{
		SceneManager.LoadScene("lose");
		SceneManager.UnloadSceneAsync("game");

	}
	public void showWinMenu()
	{
		
		SceneManager.LoadScene("win");
		SceneManager.UnloadSceneAsync("game");
	}
	
}
