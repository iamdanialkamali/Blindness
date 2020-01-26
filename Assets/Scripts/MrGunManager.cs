using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MrGunManager : MonoBehaviour {

	// Use this for initialization
	private MapManager mapManager;
	private PlayerManager playerManager;
	private EnemyManager enemyManager;
	private bool changing;
	private bool shooting;
	private bool shooted;
	private bool enemyArrived;
	private bool enemyMoving;
	private int enemys = 3;
	private bool started = true;

	private void Awake()
	{
		playerManager = GetComponent<PlayerManager>();
		mapManager = GetComponent<MapManager>();
		enemyManager = GetComponent<EnemyManager>();
	}

	void Start ()
	{
		started = true;
		Vector3 playerloc = mapManager.genrateMap(20);
		playerManager.createPlayer(playerloc);
		
	}


	
	// Update is called once per frame
	void Update()
	{

		if (started)
		{
//			Debug.Log("started");
			if (enemys == 0)
			{
				SceneManager.LoadScene("win");

//				Debug.Log("I WIN I WIN");
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
					enemyManager.checkMovment();
					enemyMoving = true;
				}
			}
			else
			{
				started = false;
				SceneManager.LoadScene("lose");

//				Debug.Log("YOU ARE FUCKING DEAD");
			}

		}
	}

}
