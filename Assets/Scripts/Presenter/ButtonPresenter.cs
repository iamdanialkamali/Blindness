using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPresenter : MonoBehaviour {
	
	private RTLTextMeshPro point;
	private PlayerModel.PlayerData model;
	// Use this for initialization
	void Start ()
	{
		point = GameObject.FindWithTag("point").GetComponent<RTLTextMeshPro>();
		string loadString = PlayerPrefs.GetString("PlayerData");
		model =  JsonUtility.FromJson<PlayerModel.PlayerData>(loadString);
		point.text = model.points.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goToGame()
	{
		SceneManager.LoadScene("game");
	}
	public void startGame()
	{
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
