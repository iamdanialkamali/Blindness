using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public Camera menuCamera;
	public Camera gameCamera;
	private GameObject menu;
	public GameObject firstPage;
	public GameObject lose;
	public GameObject win;
	public GameObject map;
	private GameObject mapReserve;
	private GameObject player;
	// Use this for initialization
	void Start ()
	{
		gameCamera.enabled = false;
		menuCamera.enabled = true;
		menu = firstPage;
		player = GameObject.Find("player(Clone)");

	}
	
	// Update is called once per frame
	void Update () {

		if (player != null)
		{
			gameCamera.transform.position = new Vector3((float)-3.8,player.transform.position.y,-10); ;
			
		}else
		{
			player = GameObject.Find("player(Clone)");
		}

		
	}

	public void startGame()
	{
		
		Debug.Log("WHYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
		gameCamera.enabled = true;
		menuCamera.enabled = false;
		menu.SetActive(false);

		GetComponent<MrGunManager>().start();
	}

	public void showLoseMenu()
	{
		menuCamera.enabled = true;
		gameCamera.enabled = false;
		menu.SetActive(false);
		menu = lose;
		menu.SetActive(true);

	}
	public void showWinMenu()
	{
		
		menuCamera.enabled = true;
		gameCamera.enabled = false;
		menu.SetActive(false);
		menu = win;
		menu.SetActive(true);
		
	}
	
}
