using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MrGunManager : MonoBehaviour {

	// Use this for initialization
	private MapManager mapManager;
	private PlayerManager playerManager;
	private EnemyManager enemyManager;
	private MenuManager menuManager;
	private bool changing;
	private bool shooting;
	private bool shooted;
	private bool enemyArrived;
	private bool enemyMoving;
	private int enemys = 1;
	private bool started = false;

	private void Awake()
	{
		menuManager = GetComponent<MenuManager>();
		playerManager = GetComponent<PlayerManager>();
		mapManager = GetComponent<MapManager>();
		enemyManager = GetComponent<EnemyManager>();
	}

	void Start ()
	{
		
	}

	public void start()
	{
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("stair"))
		{
			Destroy(g);
		}
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("player"))
		{
			Destroy(g);
		}
//		foreach (GameObject g in GameObject.FindGameObjectsWithTag("line"))
//		{
//			Destroy(g);
//		}
		started = true;
		Vector3 playerloc = mapManager.genrateMap(20);
		playerManager.createPlayer(playerloc);

	}
	
	// Update is called once per frame
	void Update()
	{

		if (started)
		{
			Debug.Log("started");
			if (enemys == 0)
			{
				menuManager.showWinMenu();
				Debug.Log("I WIN I WIN");
				started = false;
			}
			else if (playerManager.isAlive())
			{
				bool arrived = playerManager.movePlayer();
				if (arrived && !shooted)
				{
					enemyManager.createEnemy(playerManager.getSign(), playerManager.getPlayer(), enemys);
					shooting = true;
				}

				if (shooting && Input.GetKeyDown(KeyCode.Space))
				{
					playerManager.shoot();
					StartCoroutine(enemyManager.shoot());
					shooted = true;
					shooting = false;
				}

				if (!enemyManager.isEnemyDead() && enemyMoving)
				{
					enemyArrived = enemyManager.moveEnemy();
					if (enemyArrived)
					{
						playerManager.checkMovement();
						enemyMoving = false;
						shooted = false;
					}

				}

				if (shooted && enemyManager.isEnemyDead())
				{
					enemys--;
					shooted = false;
					playerManager.checkMovement();
				}

				if (enemyManager.getStillPlaying() && !changing)
				{
					changing = true;
//				playerManager.checkMovement();
					enemyManager.checkMovment();
					enemyMoving = true;
				}
			}
			else
			{
				started = false;
				menuManager.showLoseMenu();
				Debug.Log("YOU ARE FUCKING DEAD");
			}

		}
	}

}
